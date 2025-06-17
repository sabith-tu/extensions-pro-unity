#if UNITY_EDITOR
using SABI;
using SABI.Flow;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

namespace SABI
{
    public class SpriteGenerator : EditorWindow
    {
        [MenuItem("Window/SpriteGenerator")]
        private static void ShowWindow()
        {
            var window = GetWindow<SpriteGenerator>();
            window.titleContent = new GUIContent("SpriteGenerator");
            window.Show();
        }

        int width = 1000,
            height = 1000;
        float borderRadiusTopLeft = 400,
            borderRadiusTopRight = 400,
            borderRadiusBottomRight = 400,
            borderRadiusBottomLeft = 400;
        Color bgColor = new Color(1, 1, 1);
        string imageName = "SpriteGenerator";

        void CreateGUI()
        {
            var widthField = new IntegerField("Width")
                .SetValue(width)
                .OnValueChange(value => width = value.newValue)
                .LabelWidth(200);

            var heightField = new IntegerField("Height")
                .SetValue(height)
                .OnValueChange(value => height = value.newValue)
                .LabelWidth(200);

            var borderRadiusTopLeftField = new FloatField("Border Radius Top Left")
                .SetValue(borderRadiusTopLeft)
                .OnValueChange(value => borderRadiusTopLeft = value.newValue)
                .LabelWidth(200);
            var borderRadiusTopRightField = new FloatField("Border Radius Top Right")
                .SetValue(borderRadiusTopRight)
                .OnValueChange(value => borderRadiusTopRight = value.newValue)
                .LabelWidth(200);
            var borderRadiusBottomLeftField = new FloatField("Border Radius Bottom Left")
                .SetValue(borderRadiusBottomLeft)
                .OnValueChange(value => borderRadiusBottomLeft = value.newValue)
                .LabelWidth(200);
            var borderRadiusBottomRightField = new FloatField("Border Radius Bottom Right")
                .SetValue(borderRadiusBottomRight)
                .OnValueChange(value => borderRadiusBottomRight = value.newValue)
                .LabelWidth(200);

            var colorField = new ColorField("Background Color")
                .SetValue(bgColor)
                .OnValueChange(value => bgColor = value.newValue)
                .LabelWidth(200);

            var nameField = new TextField("Name")
                .SetValue(imageName)
                .OnValueChange(value => imageName = value.newValue)
                .LabelWidth(200);

            Button genarateButton = new Button();
            genarateButton.text = "Genarate Image";
            genarateButton.FontSize(20);
            genarateButton
                .OnClick(
                    () =>
                        GenerateSpriteWithBorderRadius(
                            width,
                            height,
                            borderRadiusTopLeft,
                            borderRadiusTopRight,
                            borderRadiusBottomLeft,
                            borderRadiusBottomRight,
                            bgColor,
                            imageName
                        )
                )
                .Height(50)
                .BorderRadius()
                .MarginTop(10);

            rootVisualElement.Add(
                new Container(
                    new SABI.Flow.Column(
                        5,
                        5,
                        widthField,
                        heightField,
                        borderRadiusTopLeftField,
                        borderRadiusTopRightField,
                        borderRadiusBottomLeftField,
                        borderRadiusBottomRightField,
                        colorField,
                        nameField,
                        genarateButton
                    )
                )
            );
        }

        private void GenerateSpriteWithBorderRadius(
            int width,
            int height,
            float borderRadiusTL,
            float borderRadiusTR,
            float borderRadiusBL,
            float borderRadiusBR,
            Color color,
            string imageName
        )
        {
            if (imageName == null || imageName.Trim() == "")
                imageName =
                    $"[PS] Size({width},{height}), BR({borderRadiusTL},{borderRadiusTR},{borderRadiusBL},{borderRadiusBR}), C({color.r},{color.g},{color.b},{color.a})";

            Texture2D texture2D = new Texture2D(width, height);

            // Calculate squared radius for each corner (for performance optimization)
            float radiusSquaredTL = borderRadiusTL * borderRadiusTL;
            float radiusSquaredTR = borderRadiusTR * borderRadiusTR;
            float radiusSquaredBL = borderRadiusBL * borderRadiusBL;
            float radiusSquaredBR = borderRadiusBR * borderRadiusBR;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    bool isTransparent = false;

                    // Top-left corner
                    if (i < borderRadiusTL && j < borderRadiusTL)
                    {
                        float distanceSquared =
                            (i - borderRadiusTL) * (i - borderRadiusTL)
                            + (j - borderRadiusTL) * (j - borderRadiusTL);
                        isTransparent = distanceSquared > radiusSquaredTL;
                    }
                    // Top-right corner
                    else if (i >= width - borderRadiusTR && j < borderRadiusTR)
                    {
                        float distanceSquared =
                            (i - (width - borderRadiusTR)) * (i - (width - borderRadiusTR))
                            + (j - borderRadiusTR) * (j - borderRadiusTR);
                        isTransparent = distanceSquared > radiusSquaredTR;
                    }
                    // Bottom-left corner
                    else if (i < borderRadiusBL && j >= height - borderRadiusBL)
                    {
                        float distanceSquared =
                            (i - borderRadiusBL) * (i - borderRadiusBL)
                            + (j - (height - borderRadiusBL)) * (j - (height - borderRadiusBL));
                        isTransparent = distanceSquared > radiusSquaredBL;
                    }
                    // Bottom-right corner
                    else if (i >= width - borderRadiusBR && j >= height - borderRadiusBR)
                    {
                        float distanceSquared =
                            (i - (width - borderRadiusBR)) * (i - (width - borderRadiusBR))
                            + (j - (height - borderRadiusBR)) * (j - (height - borderRadiusBR));
                        isTransparent = distanceSquared > radiusSquaredBR;
                    }

                    // Set the pixel color or transparent
                    texture2D.SetPixel(i, j, isTransparent ? Color.clear : color);
                }
            }

            texture2D.Apply();
            byte[] imageData = texture2D.EncodeToPNG();
            string path = $"Assets/{imageName}.png";
            System.IO.File.WriteAllBytes(path, imageData);
            AssetDatabase.Refresh();

            var textureImporter = AssetImporter.GetAtPath(path) as UnityEditor.TextureImporter;
            if (textureImporter != null)
            {
                textureImporter.textureType = TextureImporterType.Sprite;
                textureImporter.spriteImportMode = UnityEditor.SpriteImportMode.Single;
                textureImporter.alphaIsTransparency = true;
                textureImporter.SaveAndReimport();
            }
        }
    }
}
#endif
