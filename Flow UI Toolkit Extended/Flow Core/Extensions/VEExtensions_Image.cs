using UnityEngine;
using UnityEngine.UIElements;
namespace SABI.Flow
{
    public static class VEExtensions_Image
    {
        #region Background Image
        public static T BackgroundImage<T>(this T element, Background background)
            where T : VisualElement
        {
            element.style.backgroundImage = background;
            return element;
        }

        public static T BackgroundPositionX<T>(this T element, StyleBackgroundPosition positionX)
            where T : VisualElement
        {
            element.style.backgroundPositionX = positionX;
            return element;
        }

        public static T BackgroundPositionY<T>(this T element, StyleBackgroundPosition positionY)
            where T : VisualElement
        {
            element.style.backgroundPositionY = positionY;
            return element;
        }

        public static T BackgroundRepeat<T>(this T element, BackgroundRepeat repeat)
            where T : VisualElement
        {
            element.style.backgroundRepeat = repeat;
            return element;
        }

        public static T BackgroundSize<T>(this T element, BackgroundSize size)
            where T : VisualElement
        {
            element.style.backgroundSize = size;
            return element;
        }

        public static T UnityBackgroundImageTintColor<T>(this T element, Color color)
            where T : VisualElement
        {
            element.style.unityBackgroundImageTintColor = color;
            return element;
        }
        #endregion

    }
}