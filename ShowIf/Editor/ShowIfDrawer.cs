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
            bool show = EvaluateConditions(showIf, property);

            if (show)
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
            else if (showIf.hideInsteadOfDisable)
            {
                // Do nothing, effectively hiding the field
            }
            else
            {
                GUI.enabled = false;
                EditorGUI.PropertyField(position, property, label, true);
                GUI.enabled = true;
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ShowIfAttribute showIf = (ShowIfAttribute)attribute;
            bool show = EvaluateConditions(showIf, property);

            if (show || !showIf.hideInsteadOfDisable)
            {
                return EditorGUI.GetPropertyHeight(property, label, true);
            }
            else
            {
                return 0;
            }
        }

        private bool EvaluateConditions(ShowIfAttribute showIf, SerializedProperty property)
        {
            bool result = showIf.conditionOperator == ConditionOperator.AND;

            for (int i = 0; i < showIf.conditions.Length; i++)
            {
                SerializedProperty conditionProperty = property.serializedObject.FindProperty(
                    showIf.conditions[i]
                );

                if (conditionProperty == null)
                {
                    Debug.LogWarning(
                        $"Could not find a field or property with name '{showIf.conditions[i]}'"
                    );
                    continue;
                }

                bool conditionResult = CompareProperty(
                    conditionProperty,
                    showIf.comparisonValues[i],
                    showIf.comparisonType
                );

                if (showIf.conditionOperator == ConditionOperator.AND)
                {
                    result &= conditionResult;
                }
                else
                {
                    result |= conditionResult;
                }
            }

            return result;
        }

        private bool CompareProperty(
            SerializedProperty property,
            object comparisonValue,
            ComparisonType comparisonType
        )
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.Boolean:
                    return Compare(property.boolValue, (bool)comparisonValue, comparisonType);
                case SerializedPropertyType.Enum:
                    return Compare(property.enumValueIndex, (int)comparisonValue, comparisonType);
                case SerializedPropertyType.Integer:
                    return Compare(property.intValue, (int)comparisonValue, comparisonType);
                case SerializedPropertyType.Float:
                    return Compare(property.floatValue, (float)comparisonValue, comparisonType);
                case SerializedPropertyType.String:
                    return Compare(property.stringValue, (string)comparisonValue, comparisonType);
                // Add more cases as needed
                default:
                    Debug.LogWarning($"Unsupported property type: {property.propertyType}");
                    return false;
            }
        }

        private bool Compare<T>(T a, T b, ComparisonType comparisonType)
            where T : System.IComparable
        {
            switch (comparisonType)
            {
                case ComparisonType.Equals:
                    return a.CompareTo(b) == 0;
                case ComparisonType.NotEquals:
                    return a.CompareTo(b) != 0;
                case ComparisonType.GreaterThan:
                    return a.CompareTo(b) > 0;
                case ComparisonType.LessThan:
                    return a.CompareTo(b) < 0;
                case ComparisonType.GreaterThanOrEqual:
                    return a.CompareTo(b) >= 0;
                case ComparisonType.LessThanOrEqual:
                    return a.CompareTo(b) <= 0;
                default:
                    return false;
            }
        }
    }
}
