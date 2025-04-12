using UnityEngine;
using UnityEngine.UIElements;
namespace SABI.Flow
{
    public static class VEExtensions_Color
    {

        #region Default Values

        static readonly Color DefaultBGColor = new Color(1f, 1f, 1f);
        static readonly Color DefaultTextColor = new Color(1f, 0.85f, 0f);

        #endregion

        #region Color

        public static T BGColor<T>(this T element, StyleColor? color = null)
            where T : VisualElement
        {
            element.style.backgroundColor = color ?? DefaultBGColor;
            return element;
        }


        public static T BGColor<T>(this T element, float r, float g, float b, float a = 1)
            where T : VisualElement
        {
            element.style.backgroundColor = new Color(r, g, b, a);
            return element;
        }

        public static T BGColor<T>(this T element, float rgb, float a = 1)
            where T : VisualElement
        {
            element.style.backgroundColor = new Color(rgb, rgb, rgb, a);
            return element;
        }

        public static T BGColorEditorDefault<T>(this T element)
            where T : VisualElement => element.BGColor(FlowUtil.GetDefaultEditorBGColor());

        public static T BGColorRandom<T>(this T element, StyleColor? color = null)
            where T : VisualElement => element.BGColor(Random.ColorHSV());

        public static T NoBGColor<T>(this T element)
            where T : VisualElement => element.BGColor(Color.clear);

        public static T NoBorderColor<T>(this T element)
            where T : VisualElement => element.BorderColor(Color.clear);

        public static T NoTextColor<T>(this T element)
                    where T : VisualElement => element.TextColor(Color.clear);

        public static T BGColor<T>(
            this T element,
            Color color1,
            Color color2,
            GradientDirection gradientDirection = GradientDirection.Horizontal,
            float gradientInfluence = 0.5f
        )
            where T : VisualElement
        {
            element.style.backgroundImage = FlowUtil.CreateGradientTexture(
                color1,
                color2,
                gradientDirection,
                gradientInfluence
            );
            // element.style.backgroundSize = StyleBackgroundSize.
            //TODO: Make it stretch
            return element;
        }

        public static T BGGradientHorizontal<T>(
            this T element,
            Color color1,
            Color color2,
            float gradientInfluence = 0.5f
        )
            where T : VisualElement => element.BGColor(color1, color2, GradientDirection.Horizontal, gradientInfluence);

        public static T BGGradientVertical<T>(
        this T element,
        Color color1,
        Color color2,
        float gradientInfluence = 0.5f
    )
        where T : VisualElement => element.BGColor(color1, color2, GradientDirection.Vertical, gradientInfluence);

        public static T Opacity<T>(this T element, float value = 0.5f)
            where T : VisualElement
        {
            element.style.opacity = value;
            return element;
        }

        public static T TextColor<T>(this T element, StyleColor? color = null)
            where T : VisualElement
        {
            element.style.color = color ?? DefaultTextColor;
            return element;
        }

        #endregion

    }
}