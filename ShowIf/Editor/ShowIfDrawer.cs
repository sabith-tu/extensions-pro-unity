using UnityEditor;
using UnityEngine;
namespace SABI
{
    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ShowIfAttribute showIf = (ShowIfAttribute)attribute;
            SerializedProperty conditionProperty = property.serializedObject.FindProperty(
                showIf.boolean
            );

            if (conditionProperty != null)
            {
                bool show = ShouldShowField(conditionProperty);
                if (show)
                {
                    EditorGUI.PropertyField(position, property, label, true);
                }
            }
            else
            {
                Debug.LogWarning($"Could not find a field or property with name '{showIf.boolean}'");
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ShowIfAttribute showIf = (ShowIfAttribute)attribute;
            SerializedProperty conditionProperty = property.serializedObject.FindProperty(
                showIf.boolean
            );

            if (conditionProperty != null && ShouldShowField(conditionProperty))
            {
                return EditorGUI.GetPropertyHeight(property, label, true);
            }
            else
            {
                return 0;
            }
        }

        private bool ShouldShowField(SerializedProperty conditionProperty)
        {
            switch (conditionProperty.propertyType)
            {
                case SerializedPropertyType.Boolean:
                    return conditionProperty.boolValue;
                case SerializedPropertyType.Enum:
                    return conditionProperty.enumValueIndex > 0;
                case SerializedPropertyType.String:
                    return !string.IsNullOrEmpty(conditionProperty.stringValue);
                // Add more cases if needed, depending on the type of condition property
                default:
                    return false;
            }
        }
    }
}