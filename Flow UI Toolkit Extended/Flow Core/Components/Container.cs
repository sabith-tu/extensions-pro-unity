using UnityEngine.UIElements;

namespace SABI.Flow
{
    public class Container : Div
    {
        public Container(VisualElement child = null)
        {
            this.Container();
            if (child != null) this.Add(child);
        }
    }
}