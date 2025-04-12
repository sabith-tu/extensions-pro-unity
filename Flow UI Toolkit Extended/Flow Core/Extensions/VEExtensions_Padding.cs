using UnityEngine;
using UnityEngine.UIElements;
namespace SABI.Flow
{
    public static class VEExtensions_Padding
    {

        #region Default Values
        const float DefaultPadding = 15;
        #endregion

        #region Padding

        public static T Padding<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.paddingBottom = value ?? DefaultPadding;
            element.style.paddingTop = value ?? DefaultPadding;
            element.style.paddingRight = value ?? DefaultPadding;
            element.style.paddingLeft = value ?? DefaultPadding;
            return element;
        }

        public static T Padding<T>(this T element, Length topBottomValue, Length leftRightValue)
            where T : VisualElement
        {
            element.style.paddingBottom = topBottomValue;
            element.style.paddingTop = topBottomValue;
            element.style.paddingRight = leftRightValue;
            element.style.paddingLeft = leftRightValue;
            return element;
        }

        public static T Padding<T>(this T element, Length top, Length bottom, Length left, Length right)
            where T : VisualElement
        {
            element.style.paddingBottom = bottom;
            element.style.paddingTop = top;
            element.style.paddingRight = right;
            element.style.paddingLeft = left;
            return element;
        }

        public static T PaddingTop<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.paddingTop = value ?? DefaultPadding;
            return element;
        }

        public static T PaddingBottom<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.paddingBottom = value ?? DefaultPadding;
            return element;
        }

        public static T PaddingLeft<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.paddingLeft = value ?? DefaultPadding;
            return element;
        }

        public static T PaddingRight<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.paddingRight = value ?? DefaultPadding;
            return element;
        }

        public static T PaddingTopBottom<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.paddingTop = value ?? DefaultPadding;
            element.style.paddingBottom = value ?? DefaultPadding;
            return element;
        }

        public static T PaddingLeftRight<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.paddingLeft = value ?? DefaultPadding;
            element.style.paddingRight = value ?? DefaultPadding;
            return element;
        }

        #endregion

    }
}