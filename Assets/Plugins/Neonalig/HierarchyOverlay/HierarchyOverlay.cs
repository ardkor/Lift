using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine.UIElements;

// ReSharper disable once RedundantNullableDirective
#nullable enable

// Draws a breadcrumbs overlay for the SceneView, allowing quick parent selection.
// i.e. "Environment / Props / Tree", where each segment is a clickable text label.

namespace Plugins.Neonalig.HierarchyOverlay {
    
    /// <summary> A breadcrumbs overlay for the SceneView, allowing quick parent selection. </summary>
    [Overlay(typeof(SceneView), id: ID, displayName: DisplayTitle, defaultDisplay: true)]
    [Icon(IconName)]
    internal sealed class HierarchyOverlay : Overlay {
        /// <summary> The unique ID of this overlay. </summary>
        internal const string ID = "Neonalig.HierarchyOverlay";
        
        /// <summary> The display title of this overlay. </summary>
        internal const string DisplayTitle = "Path Hierarchy";
        
        /// <summary> The title of the package. </summary>
        internal const string PackageTitle = "Hierarchy Overlay";

        /// <summary> The icon name of this overlay. </summary>
        internal const string IconName = "UnityEditor.SceneHierarchyWindow";
        
        /// <summary> The version of this overlay. </summary>
        internal static readonly Version Version = new(1, 0);

        /// <summary> The root element of the overlay. </summary>
        VisualElement? _Root;

        /// <summary> The scroll view of the overlay. </summary>
        ScrollView? _ScrollView;
        
        #region Overrides of Overlay

        /// <inheritdoc />
        public override void OnCreated() {
            base.OnCreated();
            Selection.selectionChanged += RepaintOverlay;
            EditorApplication.update   += FirstEditorUpdate;
            
            if (HierarchyOverlaySettings.IsFirstRun) {
                HierarchyOverlaySettings.Save();
                FirstTimeWindow.ShowAsUtility();
            }
        }

        /// <inheritdoc />
        public override void OnWillBeDestroyed() {
            base.OnWillBeDestroyed();
            Selection.selectionChanged -= RepaintOverlay;
            EditorApplication.update   -= FirstEditorUpdate;
            
            _Root       = null;
            _ScrollView = null;
        }
    
        /// <inheritdoc />
        public override VisualElement CreatePanelContent() {
            _Root = new() {
                name = DisplayTitle,
                style = {
                    flexDirection = FlexDirection.Row
                }
            };

            _ScrollView = new(ScrollViewMode.Horizontal);
            _ScrollView.Add(_Root);

            /*EditorApplication.delayCall += () => */PopulateRoot(_Root, Selection.activeGameObject);
            
            _Root.RegisterCallback<ContextClickEvent>(ShowContextMenu);
            _Root.RegisterCallback<GeometryChangedEvent>(UpdateRootSize);

            return _ScrollView;

            void ShowContextMenu( ContextClickEvent Evt ) {
                GenericMenu Menu = new();
                Menu.AddItem(EditorGUIUtility.TrTextContent("Refresh"), false, RepaintOverlay);
                // Menu.AddItem(EditorGUIUtility.TrTextContent("Update Size"), false, this.UpdateRootSize);
                // Menu.AddSeparator(string.Empty);
                HierarchyOverlaySettings.PopulateMenu(Menu, PostAction);
                Menu.ShowAsContext();
                
                void PostAction() {
                    // Force a repaint
                    RepaintOverlay();
                }
            }
            void UpdateRootSize( GeometryChangedEvent Evt ) => this.UpdateRootSize();
        }

        #endregion

        void UpdateRootSize() {
            if (_Root == null) { return; }
            SceneView LastView = SceneView.lastActiveSceneView;
            if (LastView != null) {
                Vector2 CurrentViewSize = LastView.position.size;
                _Root.style.maxWidth = CurrentViewSize.x - _Padding * 2f;
            }
        }
        
        /// <summary> Repaints the overlay. </summary>
        void RepaintOverlay() {
            if (_Root != null) {
                // Save the current selection
                GameObject? CurrentSelection = Selection.activeGameObject;

                // Clear the root element
                _Root.Clear();
                // Force a repaint
                _Root.MarkDirtyRepaint();

                // Use delayCall to add the elements back after the repaint
                EditorApplication.delayCall += OnDelayCall;
                void OnDelayCall() {
                    // Add the elements back
                    PopulateRoot(_Root, CurrentSelection);

                    // Force another repaint
                    _Root.MarkDirtyRepaint();

                    // Scroll to the end if necessary
                    if (_ScrollView != null && HierarchyOverlaySettings.ScrollToEnd) {
                        EditorApplication.delayCall += OnDelayCallInner;
                        void OnDelayCallInner() {
                            _ScrollView.horizontalScroller.value = _ScrollView.horizontalScroller.highValue;
                            _ScrollView.MarkDirtyRepaint();
                        }
                    }
                }
                
                // This nasty nested repaint is due to a Unity VisualElement ScrollView bug.
                //  Put simply, if the contents within the ScrollView already have caused an overflow (meaning the horizontal scrollbar gets shown),
                //  And we add more child elements, the scrollbar never updates so you can't scroll to them.
                //  The only fix appears to be removing elements until we don't overflow (i.e. clearing them), forcing a repaint, then adding them back, and forcing another repaint.
            }
        }
        
        /// <summary> The left and right padding for the root element. </summary>
        /// <remarks> Used predominantly in max size calculations. </remarks>
        const float _Padding = 5f;
        
        /// <summary> Raised the first time the editor updates. </summary>
        void FirstEditorUpdate() {
            EditorApplication.update -= FirstEditorUpdate;
            RepaintOverlay();
        }

        /// <summary> Populates the root element with the path to the target object. </summary>
        /// <param name="Root"> The root element to populate. </param>
        /// <param name="Target"> The target object to get the path of. </param>
        /// <param name="PathBuilder"> The string builder to use for the path. </param>
        /// <param name="NameStack"> The stack of names to use for the path. </param>
        /// <param name="NestedCall"> Whether this is a nested call. </param>
        /// <param name="IncludeTooltips"> Whether to populate the tooltip. </param>
        static void PopulateRoot( VisualElement Root, GameObject? Target, StringBuilder PathBuilder, Stack<string> NameStack, bool NestedCall, bool IncludeTooltips ) {
            if (Target == null) {
                if (!NestedCall) {
                    Root.Add(new Label("No object selected."));
                }

                return;
            }

            if (IncludeTooltips) {
                // Push the current object's name to the stack
                NameStack.Push(Target.name);
            }

            Transform? Parent = Target.transform.parent;
            if (Parent != null) {
                PopulateRoot(Root, Parent.gameObject, PathBuilder, NameStack, true, IncludeTooltips);
                Root.Add(
                    new Label("/") {
                        style = {
                            color          = Color.gray,
                            unityTextAlign = TextAnchor.MiddleCenter
                        }
                    }
                );
            }

            if (IncludeTooltips) {
                // Pop the current object's name from the stack and append it to the path
                string Name = NameStack.Pop();
                if (PathBuilder.Length > 0) {
                    // Add a separator if it's not the first element
                    PathBuilder.Append(" / ");
                }

                PathBuilder.Append(Name);
            }

            Button Button = new() {
                text = Target.name,
                style = {
                    unityTextAlign  = TextAnchor.MiddleCenter,
                    backgroundColor = Color.clear
                },
                tooltip = IncludeTooltips
                    ? $"{PathBuilder}\n\n<b>\u00B7 [ {HierarchyOverlaySettings.ControlKeyString} ]</b> to select.\n<b>\u00B7 [ {HierarchyOverlaySettings.ShiftKeyString} ]</b> to ping."
                    : string.Empty//$"{Target.name}\n\n<b>\u00B7 [ {HierarchyOverlaySettings.ControlKeyString} ]</b> to select.\n<b>\u00B7 [ {HierarchyOverlaySettings.ShiftKeyString} ]</b> to ping."
            };

            // We must use MouseUp instead of clicked, as holding shift/ctrl prevents clicked from being raised.
            Button.RegisterCallback<MouseUpEvent>(Button_MouseUp);
            Root.Add(Button);

            void Button_MouseUp( MouseUpEvent E ) {
                if (E.button != 0) { return; }

                Event Evt = E.imguiEvent;
                if (Evt.shift) {
                    PerformSelection(Target, SelectionMethod.Ping);
                } else if (Evt.control || Evt.command) {
                    PerformSelection(Target, SelectionMethod.Select);
                } else {
                    PerformSelection(Target, HierarchyOverlaySettings.SelectionMethod);
                }
            }
        }
        static void PopulateRoot( VisualElement Root, GameObject? Target ) {
            StringBuilder PathBuilder = new();
            Stack<string> NameStack   = new();
            Root.Clear();
            /*EditorApplication.delayCall += () => */PopulateRoot(Root, Target, PathBuilder, NameStack, false, HierarchyOverlaySettings.ShowPathTooltips);
        }
        
        static void PerformSelection( GameObject? Target, SelectionMethod Method ) {
            switch (Method) {
                case SelectionMethod.Select:
                    Selection.activeGameObject = Target;
                    break;
                case SelectionMethod.Ping:
                    EditorGUIUtility.PingObject(Target);
                    break;
                // default:
                //     Debug.LogError($"HierarchyOverlay.PopulateRoot: Unknown SelectionMethod: {HierarchyOverlaySettings.SelectionMethod}");
                //     break;
            }
        }

    }
}
