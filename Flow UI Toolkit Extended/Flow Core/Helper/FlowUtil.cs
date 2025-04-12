using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace SABI.Flow
{
    public static class FlowUtil
    {
        public static Texture2D CreateGradientTexture(
            Color startColor,
            Color endColor,
            GradientDirection gradientDirection = GradientDirection.Horizontal,
            float influence = 0.5f
        )
        {
            int width = (gradientDirection == GradientDirection.Horizontal) ? 256 : 1;
            int height = (gradientDirection == GradientDirection.Vertical) ? 256 : 1;

            Texture2D texture = new Texture2D(width, height);
            texture.wrapMode = TextureWrapMode.Clamp;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    float t =
                        (gradientDirection == GradientDirection.Horizontal)
                            ? (float)x / (width - 1)
                            : (float)y / (height - 1);

                    float adjustedT = AdjustTForInfluence(t, influence);

                    Color color = UnityEngine.Color.Lerp(startColor, endColor, adjustedT);
                    texture.SetPixel(x, y, color);
                }
            }

            texture.Apply();
            return texture;
        }

        private static float AdjustTForInfluence(float t, float influence)
        {
            influence = Mathf.Clamp01(influence);

            if (influence == 0)
                return 0;
            if (influence == 1)
                return 1;

            if (Mathf.Approximately(influence, 0.5f))
                return t;

            if (t <= influence)
            {
                return 0.5f * (t / influence);
            }
            else
            {
                return 0.5f + 0.5f * ((t - influence) / (1 - influence));
            }
        }

        public static List<Div> GenarateListOfDiv(Div div, int repeatCount)
        {
            List<Div> elements = new List<Div>();
            for (int i = 0; i < repeatCount; i++)
            {
                elements.Add(new Div().SetStyle(div));
            }
            return elements;
        }

        public static List<VisualElement> GenarateListOfVisualElement(VisualElement div, int repeatCount)
        {
            List<VisualElement> elements = new List<VisualElement>();
            for (int i = 0; i < repeatCount; i++)
            {
                elements.Add(new VisualElement().SetStyle(div));
            }
            return elements;
        }


        public static void CopyStyle(VisualElement transferer, VisualElement recever)
        {
            Type styleType = typeof(IStyle);
            PropertyInfo[] properties = styleType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                try
                {
                    // Skip read-only properties (e.g., 'unityFontStyleAndWeight')
                    if (!property.CanWrite || property.Name == "unityFontStyleAndWeight")
                        continue;

                    // Get the value from ve1
                    object value = property.GetValue(transferer.style);

                    // Set the value to ve2
                    property.SetValue(recever.style, value);
                }
                catch (Exception ex)
                {
                    // Handle properties that cannot be copied (e.g., unsupported types)
                    Debug.LogWarning($"Failed to copy style property '{property.Name}': {ex.Message}");
                }
            }
        }

        public static Color GetDefaultEditorBGColor() => new Color(0.21875f, 0.21875f, 0.21875f);
    }

    public enum GradientDirection
    {
        Horizontal,
        Vertical,
    }
}
