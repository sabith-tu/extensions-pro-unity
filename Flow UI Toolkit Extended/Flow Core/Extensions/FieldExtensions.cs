using System;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public static class FieldExtensions
    {
        public static BaseField<T> LabelWidth<T>(this BaseField<T> field, float width)
        {
            field.labelElement.style.width = width;
            return field;
        }

        public static BaseField<T> SetLabel<T>(this BaseField<T> field, string label)
        {
            field.label = label;
            return field;
        }

        public static BaseField<T> LabelElement<T>(
            this BaseField<T> field,
            Action<VisualElement> callback
        )
        {
            callback?.Invoke(field.labelElement);
            return field;
        }

        // ---------------------------------------------------------------------------------------------
        public static BaseField<T> OnValueChange<T>(
            this BaseField<T> field,
            EventCallback<ChangeEvent<T>> action
        )
        {
            field.RegisterValueChangedCallback(action);
            return field;
        }

        public static BaseField<T> BindPath<T>(this BaseField<T> field, string bindPath)
        {
            field.bindingPath = bindPath;
            if (field.label == null || field.label.Trim() == "")
                field.SetLabel(bindPath);
            return field;
        }

        // ---------------------------------------------------------------------------------------------
        public static BaseField<T> SetValue<T>(this BaseField<T> field, T value)
        {
            field.value = value;
            return field;
        }

        // ---------------------------------------------------------------------------------------------
    }
}
