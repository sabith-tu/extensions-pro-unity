using UnityEngine.UIElements;

namespace SABI.Flow
{
    public class Spacer : Div
    {
        public Spacer(VisualElement child = null)
        {
            this.FlexGrow().Size(0);
            if (child != null) this.Add(child);
        }
    }
}