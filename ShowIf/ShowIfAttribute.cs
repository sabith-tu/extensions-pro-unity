using UnityEngine;

namespace SABI
{
    public enum ConditionOperator
    {
        AND,
        OR,
    }

    public enum ComparisonType
    {
        Equals,
        NotEquals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
    }

    public class ShowIfAttribute : PropertyAttribute
    {
        public string[] conditions;
        public ConditionOperator conditionOperator;
        public object[] comparisonValues;
        public ComparisonType comparisonType;
        public bool hideInsteadOfDisable;

        public ShowIfAttribute(
            string condition,
            object comparisonValue = null,
            ComparisonType comparisonType = ComparisonType.Equals,
            bool hideInsteadOfDisable = true
        )
        {
            this.conditions = new[] { condition };
            this.comparisonValues = new[] { comparisonValue };
            this.comparisonType = comparisonType;
            this.hideInsteadOfDisable = hideInsteadOfDisable;
        }

        public ShowIfAttribute(ConditionOperator conditionOperator, params string[] conditions)
        {
            this.conditions = conditions;
            this.conditionOperator = conditionOperator;
            this.comparisonValues = new object[conditions.Length];
            this.comparisonType = ComparisonType.Equals;
            this.hideInsteadOfDisable = true;
        }
    }
}
