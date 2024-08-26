using System;
using UnityEngine;

namespace Plugins.Neonalig.HierarchyOverlay {
    
    /// <summary> Decorates an enum field as a toolbar picker. </summary>
    [AttributeUsage(AttributeTargets.Field)]
    internal sealed class EnumToolbarAttribute : PropertyAttribute {
        /// <summary> Decorates an enum field as a toolbar picker. </summary>
        public EnumToolbarAttribute() { }
    }
}
