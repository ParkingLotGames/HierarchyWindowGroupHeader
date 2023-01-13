#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

/// <summary>
/// This class adds headers to the hierarchy window in Unity to group objects together.
/// It is a slightly modified version of Hierarchy Window Group Header
/// http://diegogiacomelli.com.br/unitytips-hierarchy-window-group-header
/// </summary>
namespace DevTools.Editor   
{
    [InitializeOnLoad]
    public static class HeadersInHierarchy
    {
        /// <summary>
        /// The color of the header background , 90% black.
        /// </summary>
        static Color kblack = new Color(.1f, .1f, .1f, 1); 

        static HeadersInHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
        }

        /// <summary>
        /// Handles the GUI display for each item in the hierarchy window.
        /// </summary>
        /// <param name="instanceID">The instance ID of the object in the hierarchy.</param>
        /// <param name="selectionRect">The rectangle representing the object in the hierarchy.</param>
        static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (gameObject != null && gameObject.name.StartsWith("-", System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, kblack);
                EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("-", "").ToUpperInvariant());
            }
        }
    }
}
#endif
