using UnityEditor;
using UnityEngine;
using System;
using System.IO;

// ReSharper disable once RedundantNullableDirective
#nullable enable

namespace Plugins.Neonalig.HierarchyOverlay {
    [FilePath(SettingsPath, FilePathAttribute.Location.PreferencesFolder)]
    internal sealed class HierarchyOverlaySettings : ScriptableSingleton<HierarchyOverlaySettings> {
        const string _ScrollToEnd_Tooltip = "Whether to scroll to the end of the path when the selection changes";
        
        /// <inheritdoc cref="ScrollToEnd"/>
        [SerializeField, Tooltip(_ScrollToEnd_Tooltip)]
        bool _ScrollToEnd = true;
        
        /// <summary> Whether to scroll to the end of the path when the selection changes. </summary>
        internal static bool ScrollToEnd {
            get => instance._ScrollToEnd;
            set => instance._ScrollToEnd = value;
        }

        /// <summary> The control key string for the current platform. </summary>
        internal const string ControlKeyString =
            #if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
             "\u2318 Cmd";
            #else
            "^ Ctrl";
        #endif

        /// <summary> The shift key string for the current platform. </summary>
        internal const string ShiftKeyString = "\u21e7 Shift"; 

        const string _SelectionMethod_Tooltip = "The selection method for clicking on a path segment.\n\n"
            + "<b>NOTE:</b> Holding <b>[ " + ControlKeyString + " ]</b> will always select the parent object, while holding <b>[ " + ShiftKeyString + " ]</b> will always ping the parent object, regardless of this setting.";
        
        /// <inheritdoc cref="SelectionMethod"/>
        [SerializeField, EnumToolbar, Tooltip(_SelectionMethod_Tooltip)]
        SelectionMethod _SelectionMethod = SelectionMethod.Select;
        
        /// <summary> The selection method for clicking on a path segment. </summary>
        internal static SelectionMethod SelectionMethod {
            get => instance._SelectionMethod;
            set => instance._SelectionMethod = value;
        }

        const string _ShowPathTooltips_Tooltip = "Whether to show tooltips for the path segments.\n\n"
            + "<b>NOTE:</b> Generation of the tooltips is expensive, so it is only recommended to enable this if you need it.";
        
        /// <inheritdoc cref="ShowPathTooltips"/>
        [SerializeField, Tooltip(_ShowPathTooltips_Tooltip)]
        bool _ShowPathTooltips = false;
        
        /// <summary> Whether to show tooltips for the path segments. </summary>
        internal static bool ShowPathTooltips {
            get => instance._ShowPathTooltips;
            set => instance._ShowPathTooltips = value;
        }
        
        /// <summary> The path to the settings file. </summary>
        internal const string SettingsPath = "Neonalig/HierarchyOverlay/Settings.yaml";

        static bool SaveAsText => EditorSettings.serializationMode == SerializationMode.ForceText;
        
        /// <inheritdoc cref="ScriptableSingleton{T}.Save"/>
        internal static void Save() => instance.Save(SaveAsText);

        /// <summary> Resets the settings to their default values. </summary>
        void Reset() {
            _ScrollToEnd     = true;
            _SelectionMethod = SelectionMethod.Select;
        }

        /// <summary> Populates the given menu with the settings options. </summary>
        /// <param name="Menu"> The menu to populate. </param>
        /// <param name="PostAction"> The action to perform after an option is selected. </param>
        internal static void PopulateMenu( GenericMenu Menu, Action? PostAction = null ) {
            if (!IsFirstRun) {
                Menu.AddItem(
                    EditorGUIUtility.TrTextContent("Reset Settings", "Resets the settings to their default values."), false, () => {
                        instance.Reset();
                        Save();
                        PostAction?.Invoke();
                    }
                );
                Menu.AddSeparator(string.Empty);
            }
            
            // ScrollToEnd:
            Menu.AddItem(
                EditorGUIUtility.TrTextContent("Scroll to End", _ScrollToEnd_Tooltip), ScrollToEnd, () => {
                    ScrollToEnd = !ScrollToEnd;
                    Save();
                    PostAction?.Invoke();
                }
            );
            
            // SelectionMethod: (shows as nested menu)
            const string SelectionMethodMenuPath = "Selection Method/";
            foreach (SelectionMethod Method in Enum.GetValues(typeof(SelectionMethod))) {
                Menu.AddItem(
                    EditorGUIUtility.TrTextContent(SelectionMethodMenuPath + Method), Method == SelectionMethod, () => {
                        SelectionMethod = Method;
                        Save();
                        PostAction?.Invoke();
                    }
                );
            }
            
            // ShowPathTooltips:
            Menu.AddItem(
                EditorGUIUtility.TrTextContent("Show Path Tooltips", _ShowPathTooltips_Tooltip), ShowPathTooltips, () => {
                    ShowPathTooltips = !ShowPathTooltips;
                    Save();
                    PostAction?.Invoke();
                }
            );
        }

        /// <summary> Gets whether this is the first run of the plugin. </summary>
        /// <returns> <see langword="true"/> if this is the first run of the plugin; otherwise, <see langword="false"/>. </returns>
        internal static bool IsFirstRun => !File.Exists(GetFilePath());

    }
    
    /// <summary> Represents the selection method for clicking on a path segment. </summary>
    internal enum SelectionMethod {
        /// <summary> Select the parent object. </summary>
        [InspectorName("Select"), Tooltip("Select the parent object.")]
        Select,
        /// <summary> Ping the parent object. </summary>
        [InspectorName("Ping"), Tooltip("Ping the parent object.")]
        Ping
    }
}
