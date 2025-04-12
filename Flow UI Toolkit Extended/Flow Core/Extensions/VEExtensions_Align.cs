using UnityEngine.UIElements;
namespace SABI.Flow
{
    public static class VEExtensions_Align
    {
        #region Align

        public static T AlignContent<T>(this T element, StyleEnum<Align> alignContent)
            where T : VisualElement
        {
            element.style.alignContent = alignContent;
            return element;
        }

        public static T AlignItems<T>(this T element, StyleEnum<Align> alignItems)
            where T : VisualElement
        {
            element.style.alignItems = alignItems;
            return element;
        }

        public static T AlignSelf<T>(this T element, StyleEnum<Align> alignSelf)
            where T : VisualElement
        {
            element.style.alignSelf = alignSelf;
            return element;
        }

        public static T JustifyContent<T>(this T element, Justify justify)
            where T : VisualElement
        {
            element.style.justifyContent = justify;
            return element;
        }
        #endregion

        #region Flex
        public static T Flex<T>(this T element)
            where T : VisualElement
        {
            element.style.display = DisplayStyle.Flex;
            return element;
        }

        public static T FlexBasis<T>(this T element, Length flexBasis)
            where T : VisualElement
        {
            element.style.flexBasis = flexBasis;
            return element;
        }

        public static T FlexDirection<T>(this T element, FlexDirection direction)
            where T : VisualElement
        {
            element.style.flexDirection = direction;
            return element;
        }

        public static T FlexGrow<T>(this T element, float grow = 1)
            where T : VisualElement
        {
            element.style.flexGrow = grow;
            return element;
        }

        public static T FlexShrink<T>(this T element, float shrink)
            where T : VisualElement
        {
            element.style.flexShrink = shrink;
            return element;
        }

        public static T FlexWrap<T>(this T element, Wrap wrap)
            where T : VisualElement
        {
            element.style.flexWrap = wrap;
            return element;
        }

        #endregion
       
        #region Center

        public static T CenterF<T>(this T element)
            where T : VisualElement => element.Flex().JustifyContent(Justify.Center).AlignItems(Align.Center).FlexGrow(1);
        public static T CenterT<T>(this T element)
            where T : VisualElement => element.AbsolutePosition().Top(50).Left(50).Translate(-50, -50, 0);

        #endregion
    }
}
