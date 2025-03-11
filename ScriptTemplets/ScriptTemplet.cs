
using System.IO;
using UnityEditor;
using UnityEngine;

namespace SABI
{
    public static class ScriptTemplet
    {
        enum Types { None, Attribute, PropertyAttribute, PropertyAttributeAndDrawer, PropertyDrawer, Editor, EditorWindow, MonoBehaviour, MonoBehaviourAndEditor }
        static string templetPath = Application.dataPath + "/SABI/ScriptTemplets/Templets/";

        #region Genarate Script
        [MenuItem("Assets/ScriptsTemplets/MonoBehaviour")]
        static void CreateScript_MonoBehaviour()
        {
            string pathToNewFile =
                EditorUtility.SaveFilePanel("Create MonoBehaviour", GetCurrentPath(), "NewMonoBehaviour.cs", "cs");
            string pathToTemplet = templetPath + "Templet_MonoBehaviour.txt";
            CreateScript(pathToNewFile, pathToTemplet);
        }

        [MenuItem("Assets/ScriptsTemplets/Attribute")]
        static void CreateScript_Attribute()
        {
            string pathToNewFile =
                EditorUtility.SaveFilePanel("Create Attribute", GetCurrentPath(), "NewAttribute.cs", "cs");
            string pathToTemplet = templetPath + "Templet_Attribute.txt";
            CreateScript(pathToNewFile, pathToTemplet);
        }

        [MenuItem("Assets/ScriptsTemplets/PropertyDrawer")]
        static void CreateScript_PropertyDrawer()
        {
            string pathToNewFile =
                EditorUtility.SaveFilePanel("Create PropertyDrawer", GetCurrentPath(), "NewPropertyDrawer.cs", "cs");
            string pathToTemplet = templetPath + "Templet_PropertyDrawer.txt";
            CreateScript(pathToNewFile, pathToTemplet, Types.PropertyDrawer);
        }

        [MenuItem("Assets/ScriptsTemplets/MonoBehaviourAndEditor")]
        static void CreateScript_MonoBehaviourAndEditor()
        {
            string pathToNewFile =
                EditorUtility.SaveFilePanel("Create MonoBehaviourAndEditor", GetCurrentPath(), "NewMonoBehaviourAndEditor.cs", "cs");
            string pathToTemplet = templetPath + "Templet_MonoBehaviourAndEditor.txt";
            CreateScript(pathToNewFile, pathToTemplet);
        }

        [MenuItem("Assets/ScriptsTemplets/Editor")]
        static void CreateScript_Editor()
        {
            string pathToNewFile =
                EditorUtility.SaveFilePanel("Create Editor", GetCurrentPath(), "NewEditor.cs", "cs");
            string pathToTemplet = templetPath + "Templet_Editor.txt";
            CreateScript(pathToNewFile, pathToTemplet, Types.Editor);
        }

        [MenuItem("Assets/ScriptsTemplets/EditorWindow")]
        static void CreateScript_EditorWindow()
        {
            string pathToNewFile =
                EditorUtility.SaveFilePanel("Create EditorWindow", GetCurrentPath(), "NewEditorWindow.cs", "cs");
            string pathToTemplet = templetPath + "Templet_EditorWindow.txt";
            CreateScript(pathToNewFile, pathToTemplet);
        }

        [MenuItem("Assets/ScriptsTemplets/PropertyAttribute")]
        static void CreateScript_PropertyAttribute()
        {
            string pathToNewFile =
                EditorUtility.SaveFilePanel("Create PropertyAttribute", GetCurrentPath(), "NewPropertyAttribute.cs", "cs");
            string pathToTemplet = templetPath + "Templet_PropertyAttribute.txt";
            CreateScript(pathToNewFile, pathToTemplet);
        }
        [MenuItem("Assets/ScriptsTemplets/PropertyAttributeAndDrawer")]
        static void CreateScript_PropertyAttributeAndDrawer()
        {
            string pathToNewFile =
                EditorUtility.SaveFilePanel("Create PropertyAttributeAndDrawer", GetCurrentPath(), "NewPropertyAttributeAndDrawer.cs", "cs");
            string pathToTemplet = templetPath + "Templet_PropertyAttributeAndDrawer.txt";
            CreateScript(pathToNewFile, pathToTemplet, Types.PropertyAttributeAndDrawer);
        }

        [MenuItem("Assets/ScriptsTemplets/ScriptableObject")]
        static void CreateScript_ScriptableObject()
        {
            string pathToNewFile =
                EditorUtility.SaveFilePanel("Create ScriptableObject", GetCurrentPath(), "NewScriptableObjectSO.cs", "cs");
            string pathToTemplet = templetPath + "Templet_ScriptableObject.txt";
            CreateScript(pathToNewFile, pathToTemplet);
        }

        [MenuItem("Assets/ScriptsTemplets/Class")]
        static void CreateScript_Class()
        {
            string pathToNewFile =
                EditorUtility.SaveFilePanel("Create Class", GetCurrentPath(), "NewClass.cs", "cs");
            string pathToTemplet = templetPath + "Templet_Class.txt";
            CreateScript(pathToNewFile, pathToTemplet);
        }
        #endregion

        static void CreateScript(string pathToNewFile, string pathToTemplet, Types type = Types.None)
        {
            if (!string.IsNullOrEmpty(pathToNewFile))
            {
                FileInfo fileInfo = new FileInfo(pathToNewFile);
                string nameOfScript = Path.GetFileNameWithoutExtension(fileInfo.Name);

                string text = File.ReadAllText(pathToTemplet);

                text = text.Replace("#ScriptName#", nameOfScript);

                switch (type)
                {
                    case Types.PropertyAttributeAndDrawer:
                        string drawerName = nameOfScript;
                        if (drawerName.EndsWith("Attribute"))
                            drawerName = nameOfScript.Substring(0, drawerName.Length - "Attribute".Length);
                        text = text.Replace("#DrawerName#", drawerName + "Drawer");
                        break;
                    case Types.PropertyDrawer:
                        string attributeName = nameOfScript;
                        if (attributeName.EndsWith("Drawer"))
                            attributeName = nameOfScript.Substring(0, attributeName.Length - "Drawer".Length);
                        text = text.Replace("#AttributeName#", attributeName);
                        break;
                    case Types.Editor:
                        string targetName = nameOfScript;
                        if (targetName.EndsWith("Editor"))
                            targetName = nameOfScript.Substring(0, targetName.Length - "Editor".Length);
                        text = text.Replace("#TargetName#", targetName);
                        break;
                }

                File.WriteAllText(pathToNewFile, text);
                AssetDatabase.Refresh();
            }
        }

        static string GetCurrentPath()
        {
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
