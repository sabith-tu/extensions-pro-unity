#if UNITY_EDITOR

using System.IO;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEditor.SceneManagement;
using UnityEditor.Toolbars;
using UnityEngine;
using Scene = UnityEngine.SceneManagement.Scene;

namespace SABI
{
    [Overlay(typeof(SceneView), "Scene Selector")]
    // [Icon("Assets/t.png")]
    public class SceneSelector : ToolbarOverlay
    {
        SceneSelector()
            : base(MainSceneDropDownToggle.id, AllSceneDropDownToggle.id) { }

        [EditorToolbarElement(id, typeof(SceneView))]
        class MainSceneDropDownToggle : EditorToolbarButton, IAccessContainerWindow
        {
            public EditorWindow containerWindow { get; set; }

            public const string id = "MainSceneDropDownToggle";

            public MainSceneDropDownToggle()
            {
                text = "Scenes in build";
                // tooltip = "All the scenes part of the ";
                // icon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/t.png");

                clicked += () =>
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

                    menu.ShowAsContext();
                };
            }
        }

        [EditorToolbarElement(id, typeof(SceneView))]
        class AllSceneDropDownToggle : EditorToolbarButton, IAccessContainerWindow
        {
            public EditorWindow containerWindow { get; set; }

            public const string id = "SceneDropDownToggle 1";

            public AllSceneDropDownToggle()
            {
                text = "All Scenes";
                tooltip = "All scenes in project";
                // icon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/t.png");

                clicked += () =>
                {
                    Scene currentScene = EditorSceneManager.GetActiveScene();
                    GenericMenu menu = new GenericMenu();
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
                                        if (
                                            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()
                                        )
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
                };
            }
        }
    }
}

#endif
