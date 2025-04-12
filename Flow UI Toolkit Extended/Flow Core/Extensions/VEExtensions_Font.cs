using UnityEngine;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public static class VEExtensions_Font
    {
        #region Default Values

        const float DefaultFontSize = 20;
        const TextOverflow DefaultTextOverflow = UnityEngine.UIElements.TextOverflow.Ellipsis;
        static readonly Color DefaultTextOutlineColor = new Color(1, 0, 0);

        #endregion

        #region FontProperties

        public static T FontSize<T>(this T element, float size = DefaultFontSize)
            where T : VisualElement
        {
            element.style.fontSize = size;
            return element;
        }

        public static T FontColor<T>(this T element, Color color)
            where T : VisualElement
        {
            element.style.color = color;
            return element;
        }

        public static T Italic<T>(this T element)
            where T : VisualElement
        {
            element.style.unityFontStyleAndWeight = FontStyle.Italic;
            return element;
        }

        public static T Bold<T>(this T element)
            where T : VisualElement
        {
            element.style.unityFontStyleAndWeight = FontStyle.Bold;
            return element;
        }

        public static T BoldAndItalic<T>(this T element)
            where T : VisualElement
        {
            element.style.unityFontStyleAndWeight = FontStyle.BoldAndItalic;
            return element;
        }

        public static T NoFontStyle<T>(this T element)
            where T : VisualElement
        {
            element.style.unityFontStyleAndWeight = FontStyle.Normal;
            return element;
        }

        public static T FontStyleAndWeight<T>(this T element, FontStyle fontStyle)
            where T : VisualElement
        {
            element.style.unityFontStyleAndWeight = fontStyle;
            return element;
        }

        public static T FontAsset<T>(this T element, Font font)
            where T : VisualElement
        {
            element.style.unityFont = font;
            return element;
        }

        public static T UnityTextAlign<T>(this T element, StyleEnum<TextAnchor> align)
            where T : VisualElement
        {
            element.style.unityTextAlign = align;
            return element;
        }

        public static T UnityTextAlignCenter<T>(this T element)
            where T : VisualElement
        {
            element.style.unityTextAlign = TextAnchor.MiddleCenter;
            return element;
        }

        public static T TextOverflow<T>(this T element, StyleEnum<TextOverflow>? overflow = null)
            where T : VisualElement
        {
            element.style.textOverflow = overflow ?? DefaultTextOverflow;
            return element;
        }

        public static T TextShadow<T>(this T element, StyleTextShadow shadow)
            where T : VisualElement
        {
            element.style.textShadow = shadow;
            return element;
        }

        public static T TextOutlineColor<T>(this T element, StyleColor? color = null)
            where T : VisualElement
        {
            element.style.unityTextOutlineColor = color ?? DefaultTextOutlineColor;
            return element;
        }

        public static T TextOutlineWidth<T>(this T element, float width = 1)
            where T : VisualElement
        {
            element.style.unityTextOutlineWidth = width;
            return element;
        }

        public static T LetterSpacing<T>(this T element, float spacing)
            where T : VisualElement
        {
            element.style.letterSpacing = spacing;
            return element;
        }

        public static T WordSpacing<T>(this T element, float spacing)
            where T : VisualElement
        {
            element.style.wordSpacing = spacing;
            return element;
        }

        public static T UnityParagraphSpacing<T>(this T element, float spacing)
            where T : VisualElement
        {
            element.style.unityParagraphSpacing = spacing;
            return element;
        }

        public static T UnityTextOverflowPosition<T>(this T element, TextOverflowPosition position)
            where T : VisualElement
        {
            element.style.unityTextOverflowPosition = position;
            return element;
        }

        public static T WhiteSpace<T>(this T element, UnityEngine.UIElements.WhiteSpace value)
            where T : VisualElement
        {
            element.style.whiteSpace = value;
            return element;
        }

        public static T TextWrap<T>(this T element)
            where T : VisualElement
        {
            return element.WhiteSpace(UnityEngine.UIElements.WhiteSpace.Normal);
        }

        #endregion

        #region Headings

        public static T H1<T>(this T element)
            where T : VisualElement => element.Bold().FontSize(32).MarginTopBottom(21.4f);

        public static T H2<T>(this T element)
            where T : VisualElement => element.Bold().FontSize(24).MarginTopBottom(18);

        public static T H3<T>(this T element)
            where T : VisualElement => element.Bold().FontSize(18.72f).MarginTopBottom(15.6f);

        public static T H4<T>(this T element)
            where T : VisualElement => element.Bold().FontSize(16).MarginTopBottom(12);

        public static T H5<T>(this T element)
            where T : VisualElement => element.Bold().FontSize(13.28f).MarginTopBottom(9);

        public static T H6<T>(this T element)
            where T : VisualElement => element.Bold().FontSize(10.72f).MarginTopBottom(7);

        #endregion
    }
}
