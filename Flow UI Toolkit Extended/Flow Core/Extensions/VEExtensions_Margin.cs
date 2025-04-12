using UnityEngine;
using UnityEngine.UIElements;
namespace SABI.Flow
{
    public static class VEExtensions_Margin
    {

        #region Default Values
        const float DefaultMargne = 15;
        #endregion

        #region Margin
        public static T Margin<T>(this T element, Length? value = null)
            where T : VisualElement
        {

            element.style.marginBottom = value ?? DefaultMargne;
            element.style.marginTop = value ?? DefaultMargne;
            element.style.marginRight = value ?? DefaultMargne;
            element.style.marginLeft = value ?? DefaultMargne;
            return element;
        }

        public static T Margin<T>(this T element, Length topBottomValue, Length leftRightValue)
            where T : VisualElement
        {
            element.style.marginBottom = topBottomValue;
            element.style.marginTop = topBottomValue;
            element.style.marginRight = leftRightValue;
            element.style.marginLeft = leftRightValue;
            return element;
        }

        public static T Margin<T>(this T element, Length top, Length bottom, Length left, Length right)
            where T : VisualElement
        {
            element.style.marginBottom = bottom;
            element.style.marginTop = top;
            element.style.marginRight = right;
            element.style.marginLeft = left;
            return element;
        }

        public static T MarginTop<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.marginTop = value ?? DefaultMargne;
            return element;
        }

        public static T MarginBottom<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.marginBottom = value ?? DefaultMargne;
            return element;
        }

        public static T MarginLeft<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.marginLeft = value ?? DefaultMargne;
            return element;
        }

        public static T MarginRight<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.marginRight = value ?? DefaultMargne;
            return element;
        }

        public static T MarginTopBottom<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.marginTop = value ?? DefaultMargne;
            element.style.marginBottom = value ?? DefaultMargne;
            return element;
        }

        public static T MarginLeftRight<T>(this T element, Length? value = null)
            where T : VisualElement
        {
            element.style.marginLeft = value ?? DefaultMargne;
            element.style.marginRight = value ?? DefaultMargne;
            return element;
        }

        #endregion

    }
}