using UnityEngine.UIElements;

namespace SABI.Flow
{
    public class Expanded : Div
    {
        public Expanded(VisualElement child = null)
        {
            this.Expand();
            if (child != null) this.Add(child);
        }
    }
}