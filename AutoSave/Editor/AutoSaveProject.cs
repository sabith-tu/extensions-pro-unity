using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SABI
{
    [InitializeOnLoad]
    public class AutoSaveProject
    {
        private static double nextSaveTime;
        private static readonly double saveInterval = 60;

        static AutoSaveProject()
        {
            EditorApplication.update += Update;
            SetNextSaveTime();
        }

        private static void Update()
        {
            if (EditorApplication.timeSinceStartup >= nextSaveTime)
            {
                SaveProject();
                SetNextSaveTime();
            }
        }

        private static void SaveProject()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                return;

            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
            Debug.Log("Project Auto-Saved");
        }

        private static void SetNextSaveTime()
        {
            nextSaveTime = EditorApplication.timeSinceStartup + saveInterval;
        }
    }
}
