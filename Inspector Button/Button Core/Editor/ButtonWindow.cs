using System.Collections.Generic;
using System.Reflection;
using SABI;
using SABI.Flow;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace SABI
{

    public class ButtonWindow : EditorWindow
    {
        private readonly Dictionary<string, List<VisualElement>> buttonGroups = new();
        private readonly Dictionary<string, object[]> methodParameters = new();

        [MenuItem("Tools/Ultimate Inspector Button Window")]
        private static void ShowWindow()
        {
            var window = GetWindow<ButtonWindow>();
            window.titleContent = new GUIContent("ButtonWindow");
            window.Show();
        }

        void CreateGUI()
        {
            ScrollView scrollable = new ScrollView();
            scrollable.verticalScrollerVisibility = ScrollerVisibility.Hidden;
            scrollable.horizontalScrollerVisibility = ScrollerVisibility.Hidden;

            rootVisualElement.Add(scrollable.Container());

            var methords = TypeCache.GetMethodsWithAttribute(typeof(ButtonAttribute));

            buttonGroups.Clear();

            foreach (var method in methords)
            {
                if (!method.IsStatic)
                    continue;

                ButtonAttribute attribute = method.GetCustomAttribute<ButtonAttribute>();
                if (attribute == null || attribute.buttonPlacement == ButtonPlacement.Inspector)
                    continue;
                ButtonDrawer.HandleButton(
                    attribute,
                    method,
                    scrollable,
                    buttonGroups,
                    methodParameters,
                    null
                );

                foreach (string item in buttonGroups.Keys)
                    scrollable.Add(new Row(buttonGroups[item]));
            }
        }
    }
}
