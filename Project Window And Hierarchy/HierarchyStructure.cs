#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SABI
{
    public class HierarchyStructure
    {
        public string Name { get; set; }
        public List<HierarchyStructure> Children { get; set; }

        public HierarchyStructure(string name)
        {
            Name = name;
            Children = new List<HierarchyStructure>();
        }
    }

    public static class HierarchyUtils
    {
        [MenuItem("GameObject/Create Hierarchy Structure")]
        static void CreateHierarchyStructure()
        {
            var root = new HierarchyStructure("ENVIRONMENT")
            {
                Children = new List<HierarchyStructure>
                {
                    new HierarchyStructure("LIGHTING") { },
                    new HierarchyStructure("CAMERAS") { },
                    new HierarchyStructure("TERRAIN"),
                    new HierarchyStructure("PROPS"),
                },
            };

            string hierarchyStructureJson = JsonUtility.ToJson(root, prettyPrint: true);
            Debug.Log("Hierarchy Structure JSON:\n" + hierarchyStructureJson);

            CreateGameObjectsFromStructure(root, null);
            CreateGameObjectsFromStructure(
                new HierarchyStructure("-----------------------------"),
                null
            );
            CreateGameObjectsFromStructure(new HierarchyStructure("MANAGERS"), null);
            CreateGameObjectsFromStructure(
                new HierarchyStructure("-----------------------------"),
                null
            );
            CreateGameObjectsFromStructure(new HierarchyStructure("UI"), null);
            CreateGameObjectsFromStructure(
                new HierarchyStructure("-----------------------------"),
                null
            );
            CreateGameObjectsFromStructure(new HierarchyStructure("GAMEPLAY"), null);
            CreateGameObjectsFromStructure(
                new HierarchyStructure("-----------------------------"),
                null
            );
            CreateGameObjectsFromStructure(new HierarchyStructure("Sandbox"), null);

            EditorApplication.RepaintHierarchyWindow();
        }

        static void CreateGameObjectsFromStructure(HierarchyStructure structure, GameObject parent)
        {
            GameObject newGameObject = new GameObject(structure.Name);

            if (parent != null)
            {
                newGameObject.transform.SetParent(parent.transform);
            }

            Undo.RegisterCreatedObjectUndo(newGameObject, "Create Hierarchy Structure");

            foreach (var child in structure.Children)
            {
                CreateGameObjectsFromStructure(child, newGameObject);
            }
        }
    }
}
#endif
