using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace SABI
{
    public static class SUtilities
    {
        /// <summary>
        /// Give the percentage of chance you want to get using UnityEngine.Random.Range().
        ///    [ 100 : always true ]
        ///    [ 0 : always false ]
        ///    [ 50 : 50% chance to be true ]
        ///    [ n : n% chance to be true ]
        /// </summary>
        /// <param name="percentage"> A value between 0 and 100 </param>
        /// <returns> boolean of weather it have the chance </returns>

        public static bool Chance(float percentage, Action OnChance = null, Action OffChance = null)
        {
            bool haveChance = percentage > Random.Range(0f, 100f);
            if (haveChance)
                OnChance?.Invoke();
            else
                OffChance?.Invoke();
            return haveChance;
        }

        public static GameObject CreateSphereAtLocation(
            Vector3 positionArg,
            string nameArg = "Unnamed",
            Color? color = null,
            float? scale = null,
            float? autoDestroyTime = null,
            bool spawnTextAlso = false,
            GameObject gameObjectToUse = null
        )
        {
            if (!CanShow())
                return new GameObject();

            GameObject newObject;
            if (gameObjectToUse == null)
                newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            else
                newObject = gameObjectToUse;

            newObject.transform.position = positionArg;
            newObject.name = "[loc] " + nameArg;

            if (gameObjectToUse == null)
            {
                newObject.transform.localScale = Vector3.one * (scale ?? 0.2f);
                newObject.GetComponent<Collider>().enabled = false;
                if (autoDestroyTime != null)
                    newObject
                        .AddComponent<AutoDestroyableInGivenTime>()
                        .SetTime(autoDestroyTime.Value);
                newObject.GetComponent<MeshRenderer>().material.color =
                    color ?? new Color(0.8f, 0.1f, 0.1f, 0.3f);
                MeshRenderer meshRenderer = newObject.GetComponent<MeshRenderer>();
                meshRenderer.material = Resources.Load<Material>("M_TransperentMaterial");
                if (color != null)
                    meshRenderer.material.color = color.Value;
            }

            if (spawnTextAlso && nameArg != "Unnamed")
            {
                float upOffset = 0.0f,
                    rightOffset = 0.0f;
                CreateTextAtLocation(
                    positionArg
                        + newObject.transform.right * rightOffset
                        + newObject.transform.up * upOffset,
                    nameArg,
                    autoDestroyTime: autoDestroyTime
                );
            }
            return newObject;
        }

        public static void Log(
            string message,
            Object context = null,
            string color = "yellow",
            string[] tags = null
        )
        {
            string tag = "";

            if (tags != null && tags.Length > 0)
            {
                foreach (var VARIABLE in tags)
                    tag += $"[{VARIABLE}] ";
            }
            else
            {
                tag = "[Log]";
            }

            if (context != null)
                Debug.Log(
                    $"<size=8>[SAB]{tag} {context.GetType().Name}</size>=><color={color}><b> {message}</b></color>",
                    context
                );
            else
                Debug.Log($"<size=8>[SAB]{tag}</size><color={color}><b> {message}</b></color>");
        }

        public static TextMeshPro CreateTextAtLocation(
            Vector3 location,
            string text,
            float fontSize = 1,
            float? autoDestroyTime = null
        )
        {
            if (!CanShow())
                return null;
            GameObject obj = new GameObject("ShowTextAtLocation {text}");
            TextMeshPro textMesh = obj.AddComponent<TextMeshPro>();
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.alignment = TextAlignmentOptions.Center;
            obj.transform.position = location;
            obj.transform.LookAt(Camera.main.transform.position);
            if (autoDestroyTime != null)
                GameObject.Destroy(obj, autoDestroyTime.Value);
            return textMesh;
        }

        public static LineRenderer CreateLine(
            Vector3 pointA,
            Vector3 pointB,
            float? autoDestroyTime = null,
            float lineWidthStart = 0.03f,
            float lineWidthEnd = 0.03f,
            Color? lineColor = null
        )
        {
            if (!CanShow())
                return null;
            GameObject obj = new GameObject($"Line from {pointA} to {pointB}");
            LineRenderer lineRenderer = obj.AddComponent<LineRenderer>();
            lineRenderer.SetPositions(new Vector3[] { pointA, pointB });
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"))
            {
                color = lineColor ?? Color.red,
            };
            lineRenderer.startWidth = lineWidthStart;
            lineRenderer.endWidth = lineWidthEnd;
            if (autoDestroyTime != null)
                GameObject.Destroy(obj, autoDestroyTime.Value);
            return lineRenderer;
        }

        public static void Log(
            string message,
            string tag,
            Object context = null,
            string color = "yellow"
        )
        {
            Log(message, context, color, (tag != null ? new string[] { tag } : null));
        }

        public static void LogGameFlow(string message, Object context = null)
        {
            try
            {
                Log(message, context, color: "green", tags: new string[] { "IMP", "GameFlow" });
            }
            catch (System.Exception e)
            {
                Debug.LogError($"LogGameFlow() error:{e}");
            }
        }

        public static T GetRandom<T>(params T[] items) => items.GetRandomItem();

        public static bool CanShow() => true;
    }
}
