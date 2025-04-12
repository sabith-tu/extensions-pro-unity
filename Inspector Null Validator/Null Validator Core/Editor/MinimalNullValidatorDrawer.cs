using SABI.Flow;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace SABI
{
    [CustomPropertyDrawer(typeof(MinimalNullValidationAttribute))]
    public class MinimalNullValidatorDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = new VisualElement();
            PropertyField propertyField = new PropertyField(property);
            root.Add(propertyField);

            MinimalNullValidationAttribute nullCheck = (MinimalNullValidationAttribute)attribute;

            Circle circle = new Circle();
            root.Add(circle);

            HandleStyling(property, circle);

            propertyField.RegisterValueChangeCallback(e =>
                HandleStyling(e.changedProperty, circle)
            );

            return root;
        }

        private static void HandleStyling(SerializedProperty changedProperty, Circle circle)
        {
            if (
                changedProperty.propertyType == SerializedPropertyType.ObjectReference
                && changedProperty.objectReferenceValue == null
            )
            {
                circle
                    .Show()
                    .AbsolutePosition()
                    .BGColor(Color.red)
                    .FixedSize(7)
                    .Left(-7)
                    .Top(0)
                    .Bottom(0)
                    .MarginTopBottom((EditorGUIUtility.singleLineHeight / 2) - 2f);
            }
            else
            {
                circle.Hide();
            }
        }
    }
}
