using System.Collections.Generic;
using System.Reflection;
using SABI.Flow;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace SABI
{
    [CustomEditor(typeof(Object), true)]
    public class ButtonInspector : Editor
    {
        private readonly Dictionary<string, List<VisualElement>> buttonGroups = new();
        private readonly Dictionary<string, object[]> methodParameters = new();

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new();

            InspectorElement.FillDefaultInspector(root, serializedObject, this);

            MethodInfo[] methods = target
                .GetType()
                .GetMethods(
                    BindingFlags.Instance
                        | BindingFlags.Static
                        | BindingFlags.Public
                        | BindingFlags.NonPublic
                );

            buttonGroups.Clear();

            foreach (MethodInfo method in methods)
            {
                ButtonAttribute attribute = method.GetCustomAttribute<ButtonAttribute>();

                if (attribute == null || attribute.buttonPlacement == ButtonPlacement.EditorWindow) continue;

                ButtonDrawer.HandleButton(
                    attribute,
                    method,
                    root,
                    buttonGroups,
                    methodParameters,
                    target
                );
            }

            foreach (string item in buttonGroups.Keys)
                root.Add(new Row(buttonGroups[item]));

            return root;
        }
    }
}
