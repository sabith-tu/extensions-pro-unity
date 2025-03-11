using UnityEngine;
using UnityEngine.UIElements;
namespace SABI.Flow
{
    public static class VEExtensions_Transform
    {
        #region Transform

        public static T Rotate<T>(this T element, StyleRotate rotate)
            where T : VisualElement
        {
            element.style.rotate = rotate;
            return element;
        }

        public static T Rotate<T>(this T element, float rotate)
            where T : VisualElement => element.Rotate(new StyleRotate(new Rotate(rotate)));


        public static T Scale<T>(this T element, StyleScale scale)
            where T : VisualElement
        {
            element.style.scale = scale;
            return element;
        }

        public static T Scale<T>(this T element, Vector3 scale)
                    where T : VisualElement
        {
            return element.Scale(new StyleScale(new Scale(scale)));
        }

        public static T Scale<T>(this T element, float scale)
            where T : VisualElement
        {
            return element.Scale(new StyleScale(new Scale(Vector3.one * scale)));
        }

        public static T Position<T>(this T element, Position position)
            where T : VisualElement
        {
            element.style.position = position;
            return element;
        }

        public static T AbsolutePosition<T>(this T element)
            where T : VisualElement
        {
            return element.Position(UnityEngine.UIElements.Position.Absolute);
        }

        public static T RelativePosition<T>(this T element)
            where T : VisualElement
        {
            return element.Position(UnityEngine.UIElements.Position.Relative);
        }

        public static T Translate<T>(this T element, StyleTranslate translate)
            where T : VisualElement
        {
            element.style.translate = translate;
            return element;
        }

        public static T Translate<T>(this T element, Vector3 translate)
            where T : VisualElement
        {
            element.style.translate = new Translate(translate.x, translate.y, translate.z);
            return element;
        }

        public static T Translate<T>(this T element, float x, float y, float z)
            where T : VisualElement
        {
            element.style.translate = new Translate(x, y, z);
            return element;
        }

        public static T TransformOrigin<T>(this T element, Length x, Length y)
            where T : VisualElement
        {
            element.style.transformOrigin = new TransformOrigin(x, y);
            return element;
        }

        #endregion

        #region Directions
        public static T Bottom<T>(this T element, Length value)
            where T : VisualElement
        {
            element.style.bottom = value;
            return element;
        }

        public static T Left<T>(this T element, Length value)
            where T : VisualElement
        {
            element.style.left = value;
            return element;
        }

        public static T Right<T>(this T element, Length value)
            where T : VisualElement
        {
            element.style.right = value;
            return element;
        }

        public static T Top<T>(this T element, Length value)
            where T : VisualElement
        {
            element.style.top = value;
            return element;
        }

        public static T StretchTopToBottom<T>(this T element, Length value)
                    where T : VisualElement => element.Top(value).Bottom(value);

        public static T StretchLeftToRight<T>(this T element, Length value)
            where T : VisualElement => element.Left(value).Right(value);

        public static T Stretch<T>(this T element, Length value)
            where T : VisualElement => element.Left(value).Right(value).Top(value).Bottom(value);

        #endregion
    }
}