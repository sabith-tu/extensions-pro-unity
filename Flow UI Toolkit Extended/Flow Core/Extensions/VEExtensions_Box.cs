using UnityEngine.UIElements;

namespace SABI.Flow
{
    public static class VEExtensions_Box
    {
        #region More

        public static T Insert<T>(this T element, params VisualElement[] children)
            where T : VisualElement
        {
            foreach (VisualElement child in children)
                element.Add(child);
            return element;
        }

        public static T Enable<T>(this T element)
            where T : VisualElement
        {
            element.SetEnabled(true);
            return element;
        }

        public static T Disable<T>(this T element)
            where T : VisualElement
        {
            element.SetEnabled(false);
            return element;
        }

        public static T Cursor<T>(this T element, StyleCursor cursor)
            where T : VisualElement
        {
            element.style.cursor = cursor;
            return element;
        }

        public static T Cursor<T>(this T element, UnityEngine.UIElements.Cursor cursor)
            where T : VisualElement
        {
            element.style.cursor = new StyleCursor(cursor);
            return element;
        }

        public static T Display<T>(this T element, DisplayStyle display)
            where T : VisualElement
        {
            element.style.display = display;
            return element;
        }

        public static T Show<T>(this T element)
            where T : VisualElement
        {
            element.style.display = DisplayStyle.Flex;
            return element;
        }

        public static T Hide<T>(this T element)
            where T : VisualElement
        {
            element.style.display = DisplayStyle.None;
            return element;
        }

        public static T Overflow<T>(this T element, StyleEnum<Overflow> overflow)
            where T : VisualElement
        {
            element.style.overflow = overflow;
            return element;
        }

        public static T OverflowHidden<T>(this T element)
            where T : VisualElement
        {
            element.style.overflow = UnityEngine.UIElements.Overflow.Hidden;
            return element;
        }

        public static T OverflowVisible<T>(this T element)
            where T : VisualElement
        {
            element.style.overflow = UnityEngine.UIElements.Overflow.Visible;
            return element;
        }

        public static T Tooltip<T>(this T element, string tooltip)
            where T : VisualElement
        {
            element.tooltip = tooltip;
            return element;
        }

        public static T SetStyle<T>(this T element, T transferer)
            where T : VisualElement
        {
            FlowUtil.CopyStyle(transferer, element);
            return element;
        }

        public static T SetParent<T>(this T element, VisualElement parent)
            where T : VisualElement
        {
            parent.Add(element);
            return element;
        }

        #endregion
    }
}
