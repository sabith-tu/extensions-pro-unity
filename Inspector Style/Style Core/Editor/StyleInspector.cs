using System;
using System.Collections.Generic;
using System.Reflection;
using SABI.Flow;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;


namespace SABI
{
    [CustomPropertyDrawer(typeof(StyleAttribute), true)]
    public class StyleInspector : PropertyDrawer
    {
        private Dictionary<string, List<VisualElement>> buttonGroups = new Dictionary<string, List<VisualElement>>();
        private Dictionary<string, object[]> methodParameters = new Dictionary<string, object[]>();



        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            PropertyField propertyField = new PropertyField(property);
            StyleAttribute style = (StyleAttribute)attribute;
            Style(propertyField, style);
            return propertyField;
        }



        public void Style(VisualElement element, StyleAttribute attribute)
        {

            buttonGroups.Clear();

            element
                // .CenterF()
                .OnHover(
                    element =>
                    {
                        element
                            .Width(attribute.hover_attributeStyle.width ?? Length.Auto())
                            .Height(attribute.hover_attributeStyle.height ?? 40)
                            .BGColor(
                                attribute.hover_attributeStyle.bgColor
                                    ?? attribute.attributeStyle.bgColor
                                    ?? new Color(0.3f, 0.3f, 0.3f),
                                attribute.hover_attributeStyle.bgColor2
                                    ?? attribute.hover_attributeStyle.bgColor
                                    ?? attribute.attributeStyle.bgColor
                                    ?? new Color(0.3f, 0.3f, 0.3f)
                            )
                            .Margin(attribute.hover_attributeStyle.margin ?? 5)
                            .Padding(attribute.hover_attributeStyle.padding ?? 10)
                            .BorderRadius(attribute.hover_attributeStyle.borderRadius ?? 10)
                            .BorderWidth(attribute.hover_attributeStyle.borderWidth ?? 0)
                            .BorderColor(
                                attribute.hover_attributeStyle.borderColor
                                    ?? attribute.attributeStyle.borderColor
                                    ?? Color.yellow,
                                attribute.hover_attributeStyle.borderColor2
                                    ?? attribute.hover_attributeStyle.borderColor
                                    ?? attribute.attributeStyle.borderColor
                                    ?? Color.yellow
                            )
                            .Opacity(attribute.hover_attributeStyle.opacity ?? 1)
                            .Rotate(
                                new StyleRotate(
                                    new Rotate(attribute.hover_attributeStyle.rotation ?? 0)
                                )
                            )
                            .Tooltip(attribute.hover_attributeStyle.tooltip ?? "");


                    },
                    element =>
                    {
                        element
                            .Width(attribute.attributeStyle.width ?? Length.Auto())
                            .Height(attribute.attributeStyle.height ?? 40)
                            .BGColor(
                                attribute.attributeStyle.bgColor
                                    ?? new Color(0.3f, 0.3f, 0.3f),
                                attribute.attributeStyle.bgColor2
                                    ?? attribute.attributeStyle.bgColor
                                    ?? new Color(0.3f, 0.3f, 0.3f)
                            )
                            .Margin(attribute.attributeStyle.margin ?? 5)
                            .Padding(attribute.attributeStyle.padding ?? 10)
                            .BorderRadius(attribute.attributeStyle.borderRadius ?? 10)
                            .BorderWidth(attribute.attributeStyle.borderWidth ?? 0)
                            .BorderColor(
                                attribute.attributeStyle.borderColor ?? Color.white,
                                attribute.attributeStyle.borderColor2
                                    ?? attribute.attributeStyle.borderColor
                                    ?? Color.white
                            )
                            .Opacity(attribute.attributeStyle.opacity ?? 1)
                            .Rotate(
                                new StyleRotate(
                                    new Rotate(attribute.attributeStyle.rotation ?? 0)
                                )
                            )
                            .Tooltip(attribute.attributeStyle.tooltip ?? "");

                    }
                );





            // Div parametersAndButton = new Div(new Flow.Column(button))
            //     .OnHover(
            //         (element) =>
            //         {
            //             element
            //                 .BorderRadius(attribute.attributeStyle.borderRadius ?? 10)
            //                 .BorderWidth(1)
            //                 .BorderColor(
            //                     attribute.attributeStyle.borderColor ?? Color.yellow
            //                 );
            //         },
            //         (element) =>
            //         {
            //             element
            //                 .BorderRadius(attribute.hover_attributeStyle.borderRadius ?? 10)
            //                 .BorderWidth(1)
            //                 .BorderColor(
            //                     attribute.hover_attributeStyle.borderColor ?? Color.white
            //                 );
            //         }
            //     )
            //     .Padding(5)
            //     .MarginTopBottom(attribute.attributeStyle.margin ?? 5);

        }
    }
}
