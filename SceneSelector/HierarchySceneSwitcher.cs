#if UNITY_EDITOR

using System.IO;
using SABI;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class HierarchySceneSwitcher
{
    private static bool buttonDrawnThisFrame;

    static HierarchySceneSwitcher()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
    }

    private static void OnHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        if (Event.current.type == EventType.Repaint)
            buttonDrawnThisFrame = false;

        if (!buttonDrawnThisFrame && selectionRect.y <= 2f)
        {
            Rect buttonRect = new Rect(EditorGUIUtility.currentViewWidth - 45, 0, 20, 15);

            if (GUI.Button(buttonRect, EditorGUIUtility.IconContent("d_icon dropdown")))
                ShowSceneSwitchMenu();

            buttonDrawnThisFrame = true;
        }
    }

    private static void ShowSceneSwitchMenu()
    {
        Scene currentScene = EditorSceneManager.GetActiveScene();
        GenericMenu menu = new GenericMenu();

        EditorBuildSettings.scenes.ForEach(item =>
        {
            string path = item.path;
            string name = Path.GetFileNameWithoutExtension(path);
            menu.AddItem(
                new GUIContent(name),
                string.Compare(currentScene.name, name) == 0,
                () =>
                {
                    if (currentScene.isDirty)
                    {
                        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                        {
                            EditorSceneManager.OpenScene(path);
                        }
                    }
                    else
                    {
                        EditorSceneManager.OpenScene(path);
                    }
                }
            );
        });

        menu.AddItem(new GUIContent(""), false, null);

        AssetDatabase
            .FindAssets("t:scene", null)
            .ForEach(item =>
            {
                string path = AssetDatabase.GUIDToAssetPath(item);
                string name = Path.GetFileNameWithoutExtension(path);
                menu.AddItem(
                    new GUIContent(path),
                    string.Compare(currentScene.name, name) == 0,
                    () =>
                    {
                        if (currentScene.isDirty)
                        {
                            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                            {
                                EditorSceneManager.OpenScene(path);
                            }
                        }
                        else
                        {
                            EditorSceneManager.OpenScene(path);
                        }
                    }
                );
            });

        menu.AddItem(new GUIContent(""), false, null);

        AssetDatabase
            .FindAssets("t:scene", null)
            .ForEach(item =>
            {
                string path = AssetDatabase.GUIDToAssetPath(item);
                string name = Path.GetFileNameWithoutExtension(path);
                if (path.Contains("Packages/"))
                    return;
                menu.AddItem(
                    new GUIContent(name),
                    string.Compare(currentScene.name, name) == 0,
                    () =>
                    {
                        if (currentScene.isDirty)
                        {
                            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                            {
                                EditorSceneManager.OpenScene(path);
                            }
                        }
                        else
                        {
                            EditorSceneManager.OpenScene(path);
                        }
                    }
                );
            });

        menu.ShowAsContext();
    }
}

#endif
