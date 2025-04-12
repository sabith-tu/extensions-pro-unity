using System;
using UnityEngine;
using UnityEngine.UIElements;
namespace SABI.Flow
{
    public static class VEExtensions_Events
    {
        #region Events
        public static T OnClick<T>(this T element, Action callback)
            where T : VisualElement
        {
            element.RegisterCallback<ClickEvent>(evt => callback());
            return element;
        }

        public static T OnMouseEnter<T>(this T element, Action callback)
            where T : VisualElement
        {
            element.RegisterCallback<MouseEnterEvent>(evt => callback());
            return element;
        }

        public static T OnMouseLeave<T>(this T element, Action callback)
            where T : VisualElement
        {
            element.RegisterCallback<MouseLeaveEvent>(evt => callback());
            return element;
        }

        public static T OnMouseDown<T>(this T element, Action callback)
            where T : VisualElement
        {
            element.RegisterCallback<MouseDownEvent>(evt => callback());
            return element;
        }

        public static T OnMouseUp<T>(this T element, Action callback)
            where T : VisualElement
        {
            element.RegisterCallback<MouseUpEvent>(evt => callback());
            return element;
        }

        public static T OnKeyDown<T>(this T element, Action<KeyDownEvent> callback)
            where T : VisualElement
        {
            element.RegisterCallback<KeyDownEvent>(evt => callback(evt));
            return element;
        }

        public static T OnKeyUp<T>(this T element, Action<KeyUpEvent> callback)
            where T : VisualElement
        {
            element.RegisterCallback<KeyUpEvent>(evt => callback(evt));
            return element;
        }

        public static T OnFocus<T>(this T element, Action callback)
            where T : VisualElement
        {
            element.RegisterCallback<FocusInEvent>(evt => callback());
            return element;
        }

        public static T OnBlur<T>(this T element, Action callback)
            where T : VisualElement
        {
            element.RegisterCallback<FocusOutEvent>(evt => callback());
            return element;
        }


        #endregion

        #region Events With Element
        public static T OnClick<T>(this T element, Action<T> callback)
            where T : VisualElement
        {
            element.RegisterCallback<ClickEvent>(evt => callback(element));
            return element;
        }

        public static T OnHover<T>(this T element, Action<T> onEnter, Action<T> onExit)
            where T : VisualElement
        {
            onExit(element);
            return element.Animate().OnMouseEnter(onEnter).OnMouseLeave(onExit);
        }

        public static T OnMouseEnter<T>(this T element, Action<T> callback)
            where T : VisualElement
        {
            element.RegisterCallback<MouseEnterEvent>(evt => callback(element));
            return element;
        }

        public static T OnMouseLeave<T>(this T element, Action<T> callback)
            where T : VisualElement
        {
            element.RegisterCallback<MouseLeaveEvent>(evt => callback(element));
            return element;
        }

        public static T OnMouseDown<T>(this T element, Action<T> callback)
            where T : VisualElement
        {
            element.RegisterCallback<MouseDownEvent>(evt => callback(element)); ;
            return element;
        }

        public static T OnMouseUp<T>(this T element, Action<T> callback)
            where T : VisualElement
        {
            element.RegisterCallback<MouseUpEvent>(evt => callback(element));
            return element;
        }

        public static T OnKeyDown<T>(this T element, Action<KeyDownEvent, T> callback)
            where T : VisualElement
        {
            element.RegisterCallback<KeyDownEvent>(evt => callback(evt, element));
            return element;
        }

        public static T OnKeyUp<T>(this T element, Action<KeyUpEvent, T> callback)
            where T : VisualElement
        {
            element.RegisterCallback<KeyUpEvent>(evt => callback(evt, element));
            return element;
        }

        public static T OnFocus<T>(this T element, Action<T> callback)
            where T : VisualElement
        {
            element.RegisterCallback<FocusInEvent>(evt => callback(element));
            return element;
        }

        public static T OnBlur<T>(this T element, Action<T> callback)
            where T : VisualElement
        {
            element.RegisterCallback<FocusOutEvent>(evt => callback(element));
            return element;
        }


        #endregion

    }
}