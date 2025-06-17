#if UNITY_EDITOR

using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace SABI
{
    public class FolderStructure
    {
        public string Name { get; set; }
        public List<FolderStructure> SubFolders { get; set; }

        public FolderStructure(string name)
        {
            Name = name;
            SubFolders = new List<FolderStructure>();
        }
    }

    public static class GenerateFolderStructure
    {
        static bool userUnderScore = true;

        [MenuItem("Assets/Create Folder Structure")]
        static void CreateFolderStructure()
        {
            var root = new FolderStructure("_Project")
            {
                SubFolders = new()
                {
                    new(GenerateName("Scripts")),
                    new(GenerateName("Art"))
                    {
                        SubFolders = new()
                        {
                            new(GenerateName("Materials")),
                            new(GenerateName("Audio")),
                            new(GenerateName("AnimationController")),
                            new(GenerateName("Animation Clip")),
                            new(GenerateName("Sprites")),
                            new(GenerateName("Textures")),
                            new(GenerateName("Models")),
                        },
                    },
                    new(GenerateName("Prefabs")),
                    new(GenerateName("Data")),
                    new(GenerateName("Scenes")),
                    new("Resources"),
                    new("Editor"),
                },
            };

            CreateFoldersFromStructure(root, "Assets");
            CreateFoldersFromStructure(new FolderStructure("ThirdParty"), "Assets");
            CreateFoldersFromStructure(new FolderStructure("Sandbox"), "Assets");
            AssetDatabase.Refresh();
        }

        static void CreateFoldersFromStructure(FolderStructure structure, string parentPath)
        {
            string newFolderPath = Path.Combine(parentPath, structure.Name);
            if (!AssetDatabase.IsValidFolder(newFolderPath))
            {
                string guid = AssetDatabase.CreateFolder(parentPath, structure.Name);
                if (string.IsNullOrEmpty(guid))
                {
                    Debug.LogError($"Failed to create folder: {newFolderPath}");
                    return;
                }

                string folderPath = AssetDatabase.GUIDToAssetPath(guid);
                Object folderObject = AssetDatabase.LoadAssetAtPath<Object>(folderPath);
                Undo.RecordObject(folderObject, "Create Folder Structure");
            }

            foreach (var subFolder in structure.SubFolders)
            {
                CreateFoldersFromStructure(subFolder, newFolderPath);
            }
        }

        private static string GenerateName(string initialName)
        {
            if (userUnderScore)
                initialName = "_" + initialName;
            initialName = initialName;
            return initialName;
        }
    }
}
#endif
