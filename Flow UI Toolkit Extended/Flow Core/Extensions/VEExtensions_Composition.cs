using UnityEngine;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public static class VEExtensions_Composition
    {
        #region Composition

        public static T Container<T>(this T element)
            where T : VisualElement
        {
            return element.Border().Margin().Padding().Expand();
        }

        public static T Border<T>(this T element)
            where T : VisualElement => element.BorderRadius().BorderWidth().BorderColor();

        public static T Border<T>(this T element, Length radius, float width, Color color)
            where T : VisualElement =>
            element.BorderRadius(radius).BorderWidth(width).BorderColor(color);

        public static T Row<T>(this T element)
            where T : VisualElement => element.Flex().FlexDirection(FlexDirection.Row);

        public static T Column<T>(this T element)
            where T : VisualElement => element.Flex().FlexDirection(FlexDirection.Column);

        public static T ColumnReverse<T>(this T element)
            where T : VisualElement => element.Flex().FlexDirection(FlexDirection.ColumnReverse);

        public static T RowReverse<T>(this T element)
            where T : VisualElement => element.Flex().FlexDirection(FlexDirection.RowReverse);

        public static T Expand<T>(this T element, float grow = 1)
            where T : VisualElement => element.FlexGrow(grow);

        #endregion
    }
}
