using System;
using System.Collections.Generic;
using System.Reflection;

using SABI.Flow;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Column = SABI.Flow.Column;
using Object = UnityEngine.Object;

namespace SABI
{
    public static class ButtonDrawer
    {
        public static void HandleButton(
            ButtonAttribute attribute,
             MethodInfo method,
              VisualElement root,
               Dictionary<string, List<VisualElement>> buttonGroups,
                Dictionary<string, object[]> methodParameters, Object target
                )
        {

            if (attribute == null) return;

            Label label = new Label(attribute.customText ?? method.Name)
            .OnHover(element => { }, element => { })
            ;

            Button button = new Button()
                .CenterF()
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

                        label
                            .FontSize(attribute.hover_attributeStyle.textSize ?? 14)
                            .TextColor(
                                attribute.hover_attributeStyle.textColor
                                    ?? attribute.attributeStyle.textColor
                                    ?? Color.yellow
                            )
                            .TextOutlineColor(
                                attribute.hover_attributeStyle.textOutlineColor ?? Color.clear
                            )
                            .TextOutlineWidth(attribute.hover_attributeStyle.textOutlineWidth ?? 0)
                            .FontStyleAndWeight(
                                attribute.hover_attributeStyle.boldText
                                && attribute.hover_attributeStyle.italicText
                                    ? FontStyle.BoldAndItalic
                                : attribute.hover_attributeStyle.boldText ? FontStyle.Bold
                                : attribute.hover_attributeStyle.italicText ? FontStyle.Bold
                                : FontStyle.Bold
                            )
                            .UnityTextAlign(
                                attribute.hover_attributeStyle.textAlign ?? TextAnchor.MiddleCenter
                            )
                            .LetterSpacing(attribute.hover_attributeStyle.textLetterSpacing)
                            .WordSpacing(attribute.hover_attributeStyle.textWordSpacing)
                            .TextOverflow(
                                attribute.hover_attributeStyle.textOverflow ?? TextOverflow.Ellipsis
                            );
                    },
                    element =>
                    {
                        element
                            .Width(attribute.attributeStyle.width ?? Length.Auto())
                            .Height(attribute.attributeStyle.height ?? 40)
                            .BGColor(
                                attribute.attributeStyle.bgColor ?? new Color(0.3f, 0.3f, 0.3f),
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
                                new StyleRotate(new Rotate(attribute.attributeStyle.rotation ?? 0))
                            )
                            .Tooltip(attribute.attributeStyle.tooltip ?? "");
                        label
                            .FontSize(attribute.attributeStyle.textSize ?? 14)
                            .TextColor(attribute.attributeStyle.textColor ?? Color.white)
                            .TextOutlineColor(
                                attribute.attributeStyle.textOutlineColor ?? Color.clear
                            )
                            .TextOutlineWidth(attribute.attributeStyle.textOutlineWidth ?? 0)
                            .FontStyleAndWeight(
                                attribute.attributeStyle.boldText
                                && attribute.attributeStyle.italicText
                                    ? FontStyle.BoldAndItalic
                                : attribute.attributeStyle.boldText ? FontStyle.Bold
                                : attribute.attributeStyle.italicText ? FontStyle.Italic
                                : FontStyle.Normal
                            )
                            .UnityTextAlign(
                                attribute.attributeStyle.textAlign ?? TextAnchor.MiddleCenter
                            )
                            .LetterSpacing(attribute.attributeStyle.textLetterSpacing)
                            .WordSpacing(attribute.attributeStyle.textWordSpacing)
                            .TextOverflow(
                                attribute.attributeStyle.textOverflow ?? TextOverflow.Ellipsis
                            );
                    }
                );

            button.Add(label);

            ParameterInfo[] parameters = method.GetParameters();

            if (!methodParameters.ContainsKey(method.Name))
                methodParameters[method.Name] = new object[parameters.Length];

            Div parametersDiv = new Div().Width(Length.Percent(100));
            if (parameters.Length > 0)
                for (int i = 0; i < parameters.Length; i++)
                {
                    ParameterInfo param = parameters[i];

                    parametersDiv.Add(
                        DrawParameterFieldUsingUIToolkit(
                            i,
                            method.Name,
                            param,
                            methodParameters[method.Name][i], methodParameters
                        )
                    );
                }

            Foldout parametersFoldout = new() { text = "Parameters", value = false };
            parametersFoldout.Add(parametersDiv);
            parametersFoldout.Width(Length.Percent(100)).Padding(5).PaddingLeftRight(20); //.PaddingTopBottom(0);

            Div parametersAndButton = new Div(new Column(parametersFoldout, button))
                .OnHover(
                    element =>
                    {
                        element
                            .BorderRadius(attribute.attributeStyle.borderRadius ?? 10)
                            .BorderWidth(1)
                            .BorderColor(
                                attribute.attributeStyle.borderColor ?? Color.yellow
                            );
                    },
                    element =>
                    {
                        element
                            .BorderRadius(attribute.hover_attributeStyle.borderRadius ?? 10)
                            .BorderWidth(1)
                            .BorderColor(
                                attribute.hover_attributeStyle.borderColor ?? Color.white
                            );
                    }
                )
                .Padding(5)
                .MarginTopBottom(attribute.attributeStyle.margin ?? 5);

            button.OnClick(() =>
            {

                if ((attribute.buttonUsage == ButtonUsage.EveryTime) || (attribute.buttonUsage == ButtonUsage.RunTime && Application.isPlaying) || (attribute.buttonUsage == ButtonUsage.EditorTime && !Application.isPlaying))
                {

                    object result = method.Invoke(target, methodParameters[method.Name]);

                    if (method.ReturnType != typeof(void) && result != null)
                        Debug.Log($"Method {method.Name} returned: {result}");
                }
                else Debug.Log($"Methord can only be used at {attribute.buttonUsage.ToString()}");

            });


            if (attribute.groupTag != null)
            {
                if (
                    !buttonGroups.ContainsKey(attribute.groupTag)
                    || buttonGroups[attribute.groupTag] == null
                )
                    buttonGroups[attribute.groupTag] = new List<VisualElement>();

                if (parameters.Length > 0)
                    buttonGroups[attribute.groupTag].Add(parametersAndButton);
                else
                    buttonGroups[attribute.groupTag].Add(button);
            }
            else
            {
                if (parameters.Length > 0)
                    root.Add(parametersAndButton);
                else
                    root.Add(button);
            }
        }

        private static VisualElement DrawParameterFieldUsingUIToolkit(
           int index,
           string methodName,
           ParameterInfo param,
           object currentValue, Dictionary<string, object[]> methodParameters
       )
        {
            Type paramType = param.ParameterType;
            string label = ObjectNames.NicifyVariableName(param.Name);

            if (paramType == typeof(int))
            {
                IntegerField field = new(label);
                field.value = currentValue != null ? (int)currentValue : 0;
                field.RegisterValueChangedCallback(evt =>
                    methodParameters[methodName][index] = evt.newValue
                );
                return field;
            }

            if (paramType == typeof(float))
            {
                FloatField field = new(label);
                field.value = currentValue != null ? (float)currentValue : 0f;
                field.RegisterValueChangedCallback(evt =>
                    methodParameters[methodName][index] = evt.newValue
                );
                return field;
            }

            if (paramType == typeof(string))
            {
                TextField field = new(label);
                field.value = (string)currentValue ?? "";
                field.RegisterValueChangedCallback(evt =>
                    methodParameters[methodName][index] = evt.newValue
                );

                return field;
            }

            if (paramType == typeof(bool))
            {
                Toggle field = new(label);
                field.value = currentValue != null ? (bool)currentValue : false;
                field.RegisterValueChangedCallback(evt =>
                    methodParameters[methodName][index] = evt.newValue
                );
                return field;
            }

            if (paramType == typeof(Vector2))
            {
                Vector2Field field = new(label);
                field.value = currentValue != null ? (Vector2)currentValue : Vector2.zero;
                field.RegisterValueChangedCallback(evt =>
                    methodParameters[methodName][index] = evt.newValue
                );
                return field;
            }

            if (paramType == typeof(Vector3))
            {
                Vector3Field field = new(label);
                field.value = currentValue != null ? (Vector3)currentValue : Vector3.zero;
                field.RegisterValueChangedCallback(evt =>
                    methodParameters[methodName][index] = evt.newValue
                );
                return field;
            }

            if (paramType == typeof(Color))
            {
                ColorField field = new(label);
                field.value = currentValue != null ? (Color)currentValue : Color.black;
                field.RegisterValueChangedCallback(evt =>
                    methodParameters[methodName][index] = evt.newValue
                );
                return field;
            }

            if (typeof(Object).IsAssignableFrom(paramType))
            {
                ObjectField field = new(label);
                field.value = (Object)currentValue != null ? (Object)currentValue : null;
                field.RegisterValueChangedCallback(evt =>
                    methodParameters[methodName][index] = evt.newValue
                );
                return field;
            }

            if (paramType.IsEnum)
            {
                EnumField field =
                    new(
                        label,
                        currentValue != null
                            ? (Enum)currentValue
                            : (Enum)Enum.GetValues(paramType).GetValue(0)
                    );
                field.RegisterValueChangedCallback(evt =>
                    methodParameters[methodName][index] = evt.newValue
                );
                return field;
            }

            if (paramType == typeof(double))
            {
                FloatField field = new(label);
                field.value = currentValue != null ? (float)(double)currentValue : 0f;
                field.RegisterValueChangedCallback(evt =>
                    methodParameters[methodName][index] = (double)evt.newValue
                );
                return field;
            }

            if (paramType == typeof(Quaternion))
            {
                Vector4Field field = new(label);
                Quaternion quat =
                    currentValue != null ? (Quaternion)currentValue : Quaternion.identity;
                field.value = new Vector4(quat.x, quat.y, quat.z, quat.w);
                field.RegisterValueChangedCallback(evt =>
                {
                    Vector4 v = evt.newValue;
                    methodParameters[methodName][index] = new Quaternion(v.x, v.y, v.z, v.w);
                });
                return field;
            }

            // if (typeof(UnityEventBase).IsAssignableFrom(paramType))
            // {
            //     // Create an instance of the wrapper. You might cache this instance if needed.
            //     UnityEventHolder holder = CreateInstance<UnityEventHolder>();
            //     // If currentValue is not null, assign it; otherwise, initialize a new UnityEvent.
            //     holder.unityEvent = currentValue as UnityEvent ?? new UnityEvent();
            //
            //     // Create a SerializedObject for the holder.
            //     SerializedObject serializedHolder = new(holder);
            //     SerializedProperty eventProp = serializedHolder.FindProperty("unityEvent");
            //
            //     // Create a PropertyField bound to the SerializedProperty.
            //     PropertyField eventField = new(eventProp, label);
            //
            //     // Optionally, register callbacks to update your methodParameters dictionary when the event changes.
            //
            //     return eventField;
            // }


            return new HelpBox(
                $"Parameter type {paramType} is not supported",
                HelpBoxMessageType.Warning
            );
        }


    }
}