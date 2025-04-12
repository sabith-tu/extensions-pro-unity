using SABI.Flow;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace SABI
{
    [CustomPropertyDrawer(typeof(NullValidationAttribute))]
    public class NullValidatorDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = new VisualElement();
            PropertyField propertyField = new PropertyField(property);
            root.Add(propertyField);

            NullValidationAttribute nullCheck = (NullValidationAttribute)attribute;

            HelpBox helpBox = new HelpBox()
            {
                text = nullCheck.errorMessage,
                messageType = nullCheck.messageType,
            };

            HandleStyling(property, root, nullCheck, helpBox);

            root.Add(helpBox);

            propertyField.RegisterValueChangeCallback(e =>
            {
                HandleStyling(e.changedProperty, root, nullCheck, helpBox);
            });

            return root;
        }

        private static void HandleStyling(
            SerializedProperty changedProperty,
            VisualElement root,
            NullValidationAttribute nullCheck,
            HelpBox helpBox
        )
        {
            if (
                changedProperty.propertyType == SerializedPropertyType.ObjectReference
                && changedProperty.objectReferenceValue == null
            )
            {
                Color color = nullCheck.color;
                root.BGColor(nullCheck.color).Padding(5).MarginTopBottom(5).BorderRadius(10);
                if (nullCheck.drawHelpBox)
                    helpBox.Show().BorderRadius(10).Padding(5);
            }
            else
            {
                root.NoBGColor().Padding(0).Margin(0).BorderRadius(0);
                helpBox.Hide();
            }
        }
    }
}
