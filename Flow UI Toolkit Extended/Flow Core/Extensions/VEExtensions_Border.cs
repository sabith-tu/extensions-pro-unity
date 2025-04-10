using UnityEngine;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public static class VEExtensions_Border
    {
        #region Default Values
        static readonly Color DefaultBorderColor = new Color(1f, 1f, 1f);
        const float DefaultBorderRadius = 25;
        const float DefaultBorderWidth = 5;

        // public static Color DefaultBorderColor => Color.white;

        #endregion

        #region BorderWidth

        public static T BorderWidth<T>(this T element, float value = DefaultBorderWidth)
            where T : VisualElement
        {
            element.style.borderBottomWidth = value;
            element.style.borderTopWidth = value;
            element.style.borderRightWidth = value;
            element.style.borderLeftWidth = value;
            return element;
        }

        public static T BorderWidth<T>(this T element, float topBottomValue, float leftRightValue)
            where T : VisualElement
        {
            element.style.borderBottomWidth = topBottomValue;
            element.style.borderTopWidth = topBottomValue;
            element.style.borderRightWidth = leftRightValue;
            element.style.borderLeftWidth = leftRightValue;
            return element;
        }

        public static T BorderWidth<T>(
            this T element,
            float top,
            float bottom,
            float left,
            float right
        )
            where T : VisualElement
        {
            element.style.borderBottomWidth = bottom;
            element.style.borderTopWidth = top;
            element.style.borderRightWidth = right;
            element.style.borderLeftWidth = left;
            return element;
        }

        public static T BorderWidthTop<T>(this T element, float value = DefaultBorderWidth)
            where T : VisualElement
        {
            element.style.borderTopWidth = value;
            return element;
        }

        public static T BorderWidthBottom<T>(this T element, float value = DefaultBorderWidth)
            where T : VisualElement
        {
            element.style.borderBottomWidth = value;
            return element;
        }

        public static T BorderWidthLeft<T>(this T element, float value = DefaultBorderWidth)
            where T : VisualElement
        {
            element.style.borderLeftWidth = value;
            return element;
        }

        public static T BorderWidthRight<T>(this T element, float value = DefaultBorderWidth)
            where T : VisualElement
        {
            element.style.borderRightWidth = value;
            return element;
        }

        public static T BorderWidthTopBottom<T>(this T element, float value = DefaultBorderWidth)
            where T : VisualElement
        {
            element.style.borderTopWidth = value;
            element.style.borderBottomWidth = value;
            return element;
        }

        public static T BorderWidthLeftRight<T>(this T element, float value = DefaultBorderWidth)
            where T : VisualElement
        {
            element.style.borderLeftWidth = value;
            element.style.borderRightWidth = value;
            return element;
        }
        #endregion

        #region BorderRadius

        public static T BorderRadius<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.borderBottomLeftRadius = value ?? DefaultBorderRadius;
            element.style.borderBottomRightRadius = value ?? DefaultBorderRadius;
            element.style.borderTopLeftRadius = value ?? DefaultBorderRadius;
            element.style.borderTopRightRadius = value ?? DefaultBorderRadius;
            return element;
        }

        public static T BorderRadius<T>(
            this T element,
            Length topBottomValue,
            Length leftRightValue
        )
            where T : VisualElement
        {
            element.style.borderBottomLeftRadius = topBottomValue;
            element.style.borderTopLeftRadius = topBottomValue;
            element.style.borderBottomRightRadius = leftRightValue;
            element.style.borderTopRightRadius = leftRightValue;
            return element;
        }

        public static T BorderRadius<T>(
            this T element,
            Length topLeft,
            Length topRight,
            Length bottomRight,
            Length bottomLeft
        )
            where T : VisualElement
        {
            element.style.borderTopLeftRadius = topLeft;
            element.style.borderTopRightRadius = topRight;
            element.style.borderBottomRightRadius = bottomRight;
            element.style.borderBottomLeftRadius = bottomLeft;
            return element;
        }

        public static T BorderRadiusTopLeft<T>(this T element, Length value)
            where T : VisualElement
        {
            element.style.borderTopLeftRadius = value;
            return element;
        }

        public static T BorderRadiusTopRight<T>(this T element, Length value)
            where T : VisualElement
        {
            element.style.borderTopRightRadius = value;
            return element;
        }

        public static T BorderRadiusBottomLeft<T>(this T element, Length value)
            where T : VisualElement
        {
            element.style.borderBottomLeftRadius = value;
            return element;
        }

        public static T BorderRadiusBottomRight<T>(this T element, Length value)
            where T : VisualElement
        {
            element.style.borderBottomRightRadius = value;
            return element;
        }

        public static T BorderRadiusTop<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.borderTopLeftRadius = value ?? DefaultBorderRadius;
            element.style.borderTopRightRadius = value ?? DefaultBorderRadius;
            return element;
        }

        public static T BorderRadiusBottom<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.borderBottomLeftRadius = value ?? DefaultBorderRadius;
            element.style.borderBottomRightRadius = value ?? DefaultBorderRadius;
            return element;
        }

        public static T BorderRadiusLeft<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.borderTopLeftRadius = value ?? DefaultBorderRadius;
            element.style.borderBottomLeftRadius = value ?? DefaultBorderRadius;
            return element;
        }

        public static T BorderRadiusRight<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.borderTopRightRadius = value ?? DefaultBorderRadius;
            element.style.borderBottomRightRadius = value ?? DefaultBorderRadius;
            return element;
        }

        #endregion

        #region Border Color

        public static T BorderColorRandom<T>(this T element)
                    where T : VisualElement => element.BorderColor(Random.ColorHSV());



        public static T BorderColor<T>(this T element, StyleColor? color = null)
            where T : VisualElement
        {
            element.style.borderBottomColor = color ?? DefaultBorderColor;
            element.style.borderTopColor = color ?? DefaultBorderColor;
            element.style.borderLeftColor = color ?? DefaultBorderColor;
            element.style.borderRightColor = color ?? DefaultBorderColor;
            return element;
        }

        public static T BorderColor<T>(
            this T element,
            StyleColor topBottomValue,
            StyleColor leftRightValue
        )
            where T : VisualElement
        {
            element.style.borderBottomColor = topBottomValue;
            element.style.borderTopColor = topBottomValue;
            element.style.borderLeftColor = leftRightValue;
            element.style.borderRightColor = leftRightValue;
            return element;
        }

        public static T BorderColor<T>(
            this T element,
            StyleColor bottomColor,
            StyleColor topColor,
            StyleColor leftColor,
            StyleColor rightColor
        )
            where T : VisualElement
        {
            element.style.borderBottomColor = bottomColor;
            element.style.borderTopColor = topColor;
            element.style.borderLeftColor = leftColor;
            element.style.borderRightColor = rightColor;
            return element;
        }

        public static T BorderColorTop<T>(this T element, StyleColor? color = null)
            where T : VisualElement
        {
            element.style.borderTopColor = color ?? DefaultBorderColor;
            return element;
        }

        public static T BorderColorBottom<T>(this T element, StyleColor? color = null)
            where T : VisualElement
        {
            element.style.borderBottomColor = color ?? DefaultBorderColor;
            return element;
        }

        public static T BorderColorLeft<T>(this T element, StyleColor? color = null)
            where T : VisualElement
        {
            element.style.borderLeftColor = color ?? DefaultBorderColor;
            return element;
        }

        public static T BorderColorRight<T>(this T element, StyleColor? color = null)
            where T : VisualElement
        {
            element.style.borderRightColor = color ?? DefaultBorderColor;
            return element;
        }

        public static T BorderColorTopBottom<T>(this T element, StyleColor? color = null)
            where T : VisualElement
        {
            element.style.borderTopColor = color ?? DefaultBorderColor;
            element.style.borderBottomColor = color ?? DefaultBorderColor;
            return element;
        }

        public static T BorderColorLeftRight<T>(this T element, StyleColor? color = null)
            where T : VisualElement
        {
            element.style.borderLeftColor = color ?? DefaultBorderColor;
            element.style.borderRightColor = color ?? DefaultBorderColor;
            return element;
        }

        #endregion
    }
}
