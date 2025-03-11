using UnityEngine;
using UnityEngine.UIElements;
namespace SABI.Flow
{
    public static class VEExtensions_Size
    {
        #region Size

        public static T Size<T>(this T element, Length value)
            where T : VisualElement
        {
            element.style.height = value;
            element.style.width = value;
            return element;
        }

        public static T FixedSize<T>(this T element, Length width, Length height)
                where T : VisualElement
        {
            return element.MaxSize(width, height).MinSize(width, height);
        }

        public static T FixedSize<T>(this T element, Length size)
                    where T : VisualElement
        {
            return element.MaxSize(size).MinSize(size);
        }

        public static T Size<T>(this T element, Length width, Length height)
            where T : VisualElement
        {
            element.style.height = height;
            element.style.width = width;
            return element;
        }

        public static T Width<T>(this T element, Length width)
            where T : VisualElement
        {
            element.style.width = width;
            return element;
        }

        public static T Height<T>(this T element, Length height)
            where T : VisualElement
        {
            element.style.height = height;
            return element;
        }

        public static T FixedWidth<T>(this T element, Length width)
            where T : VisualElement
        {

            return element.MaxWidth(width).MinWidth(width);
        }

        public static T FixedHeight<T>(this T element, Length height)
            where T : VisualElement
        {

            return element.MaxHeight(height).MinHeight(height);
        }

        public static T MinSize<T>(this T element, Length value)
            where T : VisualElement
        {
            element.style.minHeight = value;
            element.style.minWidth = value;
            return element;
        }

        public static T MinSize<T>(this T element, Length width, Length height)
            where T : VisualElement
        {
            element.style.minHeight = height;
            element.style.minWidth = width;
            return element;
        }

        public static T MaxSize<T>(this T element, Length value)
            where T : VisualElement
        {
            element.style.maxHeight = value;
            element.style.maxWidth = value;
            return element;
        }

        public static T MaxSize<T>(this T element, Length width, Length height)
            where T : VisualElement
        {
            element.style.maxHeight = height;
            element.style.maxWidth = width;
            return element;
        }

        public static T MinHeight<T>(this T element, Length minHeight)
            where T : VisualElement
        {
            element.style.minHeight = minHeight;
            return element;
        }

        public static T MaxHeight<T>(this T element, Length maxHeight)
            where T : VisualElement
        {
            element.style.maxHeight = maxHeight;
            return element;
        }

        public static T MinWidth<T>(this T element, Length minWidth)
            where T : VisualElement
        {
            element.style.minWidth = minWidth;
            return element;
        }

        public static T MaxWidth<T>(this T element, Length maxWidth)
            where T : VisualElement
        {
            element.style.maxWidth = maxWidth;
            return element;
        }



        #endregion
    }
}