using SABI.Flow;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace SABI
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            PropertyField field = new(property);
            field.Disable();
            return field;
        }
    }
}