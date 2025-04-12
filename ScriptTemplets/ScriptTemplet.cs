#if UNITY_EDITOR

using System.IO;
using UnityEditor;
using UnityEngine;

//TODO: Interface

namespace SABI
{
    public static class ScriptTemplet
    {
        enum Types
        {
            None,
            Attribute,
            PropertyAttribute,
            PropertyAttributeAndDrawer,
            PropertyDrawer,
            Editor,
            EditorWindow,
            MonoBehaviour,
            MonoBehaviourAndEditor,
        }

        //static string templetPath = Application.dataPath + "/SABI/ScriptTemplets/Templets/";

        #region Genarate Script
        [MenuItem("Assets/ScriptsTemplets/MonoBehaviour")]
        static void CreateScript_MonoBehaviour()
        {
            string pathToNewFile = EditorUtility.SaveFilePanel(
                "Create MonoBehaviour",
                GetCurrentPath(),
                "NewMonoBehaviour.cs",
                "cs"
            );
            // string pathToTemplet = Resources.Load<TextAsset>("Templet_MonoBehaviour").text;
            CreateScript(pathToNewFile, "Templet_MonoBehaviour");
        }

        [MenuItem("Assets/ScriptsTemplets/Attribute")]
        static void CreateScript_Attribute()
        {
            string pathToNewFile = EditorUtility.SaveFilePanel(
                "Create Attribute",
                GetCurrentPath(),
                "NewAttribute.cs",
                "cs"
            );
            // string pathToTemplet = Resources.Load<TextAsset>("Templet_Attribute").text;
            CreateScript(pathToNewFile, "Templet_Attribute");
        }

        [MenuItem("Assets/ScriptsTemplets/PropertyDrawer")]
        static void CreateScript_PropertyDrawer()
        {
            string pathToNewFile = EditorUtility.SaveFilePanel(
                "Create PropertyDrawer",
                GetCurrentPath(),
                "NewPropertyDrawer.cs",
                "cs"
            );
            // string pathToTemplet = Resources.Load<TextAsset>("Templet_PropertyDrawer").text;
            CreateScript(pathToNewFile, "Templet_PropertyDrawer", Types.PropertyDrawer);
        }

        [MenuItem("Assets/ScriptsTemplets/MonoBehaviourAndEditor")]
        static void CreateScript_MonoBehaviourAndEditor()
        {
            string pathToNewFile = EditorUtility.SaveFilePanel(
                "Create MonoBehaviourAndEditor",
                GetCurrentPath(),
                "NewMonoBehaviourAndEditor.cs",
                "cs"
            );
            // string pathToTemplet = Resources.Load<TextAsset>("Templet_MonoBehaviourAndEditor").text;
            CreateScript(pathToNewFile, "Templet_MonoBehaviourAndEditor");
        }

        [MenuItem("Assets/ScriptsTemplets/Editor")]
        static void CreateScript_Editor()
        {
            string pathToNewFile = EditorUtility.SaveFilePanel(
                "Create Editor",
                GetCurrentPath(),
                "NewEditor.cs",
                "cs"
            );
            // string pathToTemplet = Resources.Load<TextAsset>("Templet_Editor").text;
            CreateScript(pathToNewFile, "Templet_Editor", Types.Editor);
        }

        [MenuItem("Assets/ScriptsTemplets/EditorWindow")]
        static void CreateScript_EditorWindow()
        {
            string pathToNewFile = EditorUtility.SaveFilePanel(
                "Create EditorWindow",
                GetCurrentPath(),
                "NewEditorWindow.cs",
                "cs"
            );
            // string pathToTemplet = Resources.Load<TextAsset>("Templet_EditorWindow").text;
            CreateScript(pathToNewFile, "Templet_EditorWindow");
        }

        [MenuItem("Assets/ScriptsTemplets/PropertyAttribute")]
        static void CreateScript_PropertyAttribute()
        {
            string pathToNewFile = EditorUtility.SaveFilePanel(
                "Create PropertyAttribute",
                GetCurrentPath(),
                "NewPropertyAttribute.cs",
                "cs"
            );
            // string pathToTemplet = Resources.Load<TextAsset>("Templet_PropertyAttribute").text;
            CreateScript(pathToNewFile, "Templet_PropertyAttribute");
        }

        [MenuItem("Assets/ScriptsTemplets/PropertyAttributeAndDrawer")]
        static void CreateScript_PropertyAttributeAndDrawer()
        {
            string pathToNewFile = EditorUtility.SaveFilePanel(
                "Create PropertyAttributeAndDrawer",
                GetCurrentPath(),
                "NewPropertyAttributeAndDrawer.cs",
                "cs"
            );
            // string pathToTemplet = Resources.Load<TextAsset>("Templet_PropertyAttributeAndDrawer").text;
            CreateScript(
                pathToNewFile,
                "Templet_PropertyAttributeAndDrawer",
                Types.PropertyAttributeAndDrawer
            );
        }

        [MenuItem("Assets/ScriptsTemplets/ScriptableObject")]
        static void CreateScript_ScriptableObject()
        {
            string pathToNewFile = EditorUtility.SaveFilePanel(
                "Create ScriptableObject",
                GetCurrentPath(),
                "NewScriptableObjectSO.cs",
                "cs"
            );
            // string pathToTemplet = Resources.Load<TextAsset>("Templet_ScriptableObject").text;
            CreateScript(pathToNewFile, "Templet_ScriptableObject");
        }

        [MenuItem("Assets/ScriptsTemplets/Class")]
        static void CreateScript_Class()
        {
            string pathToNewFile = EditorUtility.SaveFilePanel(
                "Create Class",
                GetCurrentPath(),
                "NewClass.cs",
                "cs"
            );
            // string pathToTemplet = Resources.Load<TextAsset>("Templet_Class").text;
            CreateScript(pathToNewFile, "Templet_Class");
        }
        #endregion

        static void CreateScript(
            string pathToNewFile,
            string templetFileName,
            Types type = Types.None
        )
        {
            if (!string.IsNullOrEmpty(pathToNewFile))
            {
                FileInfo fileInfo = new FileInfo(pathToNewFile);
                string nameOfScript = Path.GetFileNameWithoutExtension(fileInfo.Name);

                // string text = File.ReadAllText(templetFileName);
                string text = Resources.Load<TextAsset>(templetFileName).text;

                text = text.Replace("#ScriptName#", nameOfScript);

                switch (type)
                {
                    case Types.PropertyAttributeAndDrawer:
                        string drawerName = nameOfScript;
                        if (drawerName.EndsWith("Attribute"))
                            drawerName = nameOfScript.Substring(
                                0,
                                drawerName.Length - "Attribute".Length
                            );
                        text = text.Replace("#DrawerName#", drawerName + "Drawer");
                        break;
                    case Types.PropertyDrawer:
                        string attributeName = nameOfScript;
                        if (attributeName.EndsWith("Drawer"))
                            attributeName = nameOfScript.Substring(
                                0,
                                attributeName.Length - "Drawer".Length
                            );
                        text = text.Replace("#AttributeName#", attributeName);
                        break;
                    case Types.Editor:
                        string targetName = nameOfScript;
                        if (targetName.EndsWith("Editor"))
                            targetName = nameOfScript.Substring(
                                0,
                                targetName.Length - "Editor".Length
                            );
                        text = text.Replace("#TargetName#", targetName);
                        break;
                }

                File.WriteAllText(pathToNewFile, text);
                AssetDatabase.Refresh();
            }
        }

        static string GetCurrentPath()
        {
            if (Selection.assetGUIDs.Length == 0)
                return "Assets";

            string path = AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]);
            if (path.Contains("."))
            {
                int index = path.LastIndexOf("/");
                path = path.Substring(0, index);
            }
            return path;
        }
    }
}

#endif
