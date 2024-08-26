using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

// ReSharper disable once RedundantNullableDirective
#nullable enable

namespace Plugins.Neonalig.HierarchyOverlay {
    /// <summary> The settings provider for the hierarchy overlay. </summary>
    internal sealed class HierarchyOverlaySettingsProvider : SettingsProvider {

        /// <summary> The path to the settings window. </summary>
        internal const string Path = "Preferences/Neonalig/Hierarchy Overlay";
        
        /// <summary> The scope of the settings window. </summary>
        internal const SettingsScope Scope = SettingsScope.User;
        
        /// <summary> The URL to the asset store page for the hierarchy overlay. </summary>
        internal const string AssetStoreURL = "https://assetstore.unity.com/packages/slug/270776?aid=1011lvXjM";
        
        /// <inheritdoc />
        HierarchyOverlaySettingsProvider() : base(Path, Scope) { }

        /// <summary> The serialized settings object. </summary>
        SerializedObject? _Serialised;

        /// <summary> Container class for the styles used by the settings window. </summary>
        internal static class Styles {
            /// <summary> The centered link label style. </summary>
            internal static readonly GUIStyle CenteredLinkLabel;
            
            /// <summary> The bold centered label style. </summary>
            internal static readonly GUIStyle BoldCenteredLabel;

            /// <summary> Initialises the styles used by the settings window. </summary>
            static Styles() {
                CenteredLinkLabel = new(EditorStyles.linkLabel) {
                    alignment = TextAnchor.MiddleCenter
                };
                BoldCenteredLabel = new(EditorStyles.boldLabel) {
                    alignment = TextAnchor.MiddleCenter
                };
            }
        }

        #region Overrides of SettingsProvider

        /// <inheritdoc />
        public override void OnActivate( string SearchContext, VisualElement RootElement ) {
            base.OnActivate(SearchContext, RootElement);
            _Serialised = new(HierarchyOverlaySettings.instance);
        }

        /// <inheritdoc />
        public override void OnGUI( string SearchContext ) {
            EditorGUI.indentLevel++;
            
            if (_Serialised == null) {
                EditorGUILayout.HelpBox(nameof(HierarchyOverlaySettingsProvider) + "." + nameof(OnGUI) + ": " + nameof(_Serialised) + " is null!", MessageType.Error);
            } else {
                _Serialised.Update();
            
                SerializedProperty Iterator      = _Serialised.GetIterator();
                bool               EnterChildren = true;
                while (Iterator.NextVisible(EnterChildren)) {
                    if (Iterator.name == "m_Script") { continue; }
                    EnterChildren = false;
                    EditorGUILayout.PropertyField(Iterator, true);
                }
            
                if (_Serialised.ApplyModifiedProperties()) {
                    HierarchyOverlaySettings.Save();
                }
            }
            
            EditorGUI.indentLevel--;
            
            EditorGUILayout.Space();
            if (GUILayout.Button(EditorGUIUtility.TrTextContentWithIcon("Open First Time Window", "Info"), EditorStyles.miniButton)) {
                FirstTimeWindow.ShowAsUtility();
            }
            
            GUILayout.FlexibleSpace();
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            {
                EditorGUILayout.LabelField(EditorGUIUtility.TrTextContentWithIcon(HierarchyOverlay.PackageTitle, HierarchyOverlay.IconName), Styles.BoldCenteredLabel);
                EditorGUILayout.LabelField(EditorGUIUtility.TrTextContent($"Version {HierarchyOverlay.Version}"), EditorStyles.centeredGreyMiniLabel);
                
                EditorGUILayout.Space();
                if (GUILayout.Button(EditorGUIUtility.TrTextContent("Created by Neonalig \u2764\ufe0f"), Styles.CenteredLinkLabel, GUILayout.ExpandWidth(true))) {
                    Application.OpenURL("https://linktr.ee/neonalig");
                }
                if (!string.IsNullOrEmpty(AssetStoreURL)) {
                    if (GUILayout.Button(EditorGUIUtility.TrTextContentWithIcon("Leave a Review", "Asset Store"), EditorStyles.toolbarButton)) {
                        Application.OpenURL(AssetStoreURL);
                    }
                }
            }
            EditorGUILayout.EndVertical();
        }

        #endregion

        /// <summary> Creates the settings provider for the hierarchy overlay. </summary>
        /// <returns> The settings provider for the hierarchy overlay. </returns>
        [SettingsProvider]
        internal static SettingsProvider CreateHierarchyOverlaySettingsProvider() {
            HierarchyOverlaySettingsProvider Provider = new() {
                keywords = GetSearchKeywordsFromSerializedObject(new(HierarchyOverlaySettings.instance))
            };
            return Provider;
        }
    }

    internal sealed class FirstTimeWindow : EditorWindow {
        const string _Message =
            "{0} v{1} was successfully installed!\n\n"
            + "This overlay allows you to quickly select the parent of the selected object.\n\n"
            + "To use it, simply select an object in the SceneView, then click on the path to the object in the overlay.\n\n"
            + "You can show and hide overlays using the \u22ee button in the top right of the SceneView.\n\n"
            + "You can also right-click on the overlay to access the settings, or head to Preferences and find it there.\n\n"
            + "Enjoy!\n\n"
            + "P.S. If you like this overlay, please consider leaving a review on the Asset Store. It really helps!";

        /// <summary> Container class for the styles used by the first time window. </summary>
        static class Styles {
            /// <inheritdoc cref="HierarchyOverlaySettingsProvider.Styles.BoldCenteredLabel"/>
            static GUIStyle BoldCenteredLabel =>
                HierarchyOverlaySettingsProvider.Styles.BoldCenteredLabel;

            /// <summary> The word-wrapped centered label style. </summary>
            internal static readonly GUIStyle WordWrappedCenteredLabel;

            /// <summary> The title label style. </summary>
            internal static readonly GUIStyle TitleLabel;

            /// <summary> Initialises the styles used by the first time window. </summary>
            static Styles() {
                WordWrappedCenteredLabel = new(EditorStyles.wordWrappedLabel) {
                    // alignment = TextAnchor.MiddleCenter
                };
                TitleLabel = new(BoldCenteredLabel) {
                    fontSize = 20,
                    alignment = TextAnchor.MiddleLeft
                };
            }
        }
        
        void OnGUI() {
            GUILayout.Label(HierarchyOverlay.PackageTitle, Styles.TitleLabel);
            GUILayout.FlexibleSpace();
            
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            {
                GUILayout.Label(string.Format(_Message, HierarchyOverlay.PackageTitle, HierarchyOverlay.Version), Styles.WordWrappedCenteredLabel);
            }
            EditorGUILayout.EndVertical();
            
            GUILayout.FlexibleSpace();
            EditorGUILayout.BeginHorizontal();
            {
                if (GUILayout.Button(EditorGUIUtility.TrTextContentWithIcon("Open Settings", "Settings"), EditorStyles.miniButtonLeft)) {
                    SettingsService.OpenUserPreferences(HierarchyOverlaySettingsProvider.Path);
                    Close();
                }
                
                const string AssetStoreURL = HierarchyOverlaySettingsProvider.AssetStoreURL;
                bool         HasStoreLink  = !string.IsNullOrEmpty(AssetStoreURL);
                if (GUILayout.Button(EditorGUIUtility.TrIconContent("P4_CheckOutLocal"), HasStoreLink ? EditorStyles.miniButtonMid : EditorStyles.miniButtonRight)) {
                    Close();
                }

                if (HasStoreLink) {
                    if (GUILayout.Button(EditorGUIUtility.TrTextContentWithIcon("Open Asset Store", "Asset Store"), EditorStyles.miniButtonRight)) {
                        Application.OpenURL(AssetStoreURL);
                        Close();
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        
        internal static void ShowAsUtility() {
            FirstTimeWindow Window = GetWindow<FirstTimeWindow>(true, HierarchyOverlay.PackageTitle, true);
            Window.titleContent = EditorGUIUtility.TrTextContentWithIcon(HierarchyOverlay.PackageTitle, HierarchyOverlay.IconName);
            Window.minSize      = new(400f, 350f);
            Window.maxSize      = new(400f, 350f);
            Window.ShowUtility();
        }
    }
}
