using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SABI;
using UnityEngine;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public static class FlowPreBuild
    {
        public static VisualElement GenerateButtonSection(
            string heading,
            Dictionary<string, Action> values
        )
        {
            var buttonGroup = new Container()
                .Margin(5)
                .BorderWidth(1)
                .BGColor(Color.black.WithA(0.2f))
                .BorderColor(new Color(0.75f, 0.75f, 0.75f))
                .Insert(new Text(heading).MarginBottom(10));

            GenerateButtonGroup(values).SetParent(buttonGroup);

            return buttonGroup;
        }

        public static VisualElement GenerateButtonGroup(Dictionary<string, Action> values)
        {
            var buttonGroup = new Div();

            foreach (var item in values)
            {
                int index = values.ToList().IndexOf(item);
                GenarateButton(
                        item.Key,
                        item.Value,
                        (e) =>
                        {
                            if (values.Count < 2)
                                return;
                            if (index == 0)
                                e.BorderRadiusBottom(0);
                            else if (index == values.Count - 1)
                                e.BorderRadiusTop(0);
                            else
                                e.BorderRadius(0);
                        }
                    )
                    .SetParent(buttonGroup);
            }

            return buttonGroup;
        }

        public static VisualElement GenarateButton(
            string message,
            Action onClick,
            Action<VisualElement> visualUpdate = null
        )
        {
            Button btn = new Button() { text = message }
                .OnClick(onClick)
                .BorderRadius(15)
                .Height(30);
            visualUpdate?.Invoke(btn);
            return btn;
        }

        public static VisualElement GenerateHorizontalButtonGroup(Dictionary<string, Action> values)
        {
            var buttonGroup = new Div().Row();

            foreach (var item in values)
            {
                int index = values.ToList().IndexOf(item);
                GenarateButton(
                        item.Key,
                        item.Value,
                        (e) =>
                        {
                            if (values.Count < 2)
                                return;
                            float margineToSet = 1;
                            if (index == 0)
                                e.BorderRadiusRight(0).Expand().MarginRight(margineToSet);
                            else if (index == values.Count - 1)
                                e.BorderRadiusLeft(0).Expand().MarginLeft(margineToSet);
                            else
                                e.BorderRadius(0).Expand().MarginLeftRight(margineToSet);
                        }
                    )
                    .SetParent(buttonGroup);
            }

            return buttonGroup;
        }
    }
}
