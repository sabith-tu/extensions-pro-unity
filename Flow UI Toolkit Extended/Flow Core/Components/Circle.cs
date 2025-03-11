using UnityEngine;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public class Circle : Div
    {
        public Circle(VisualElement child = null, float size = 50)
        {
            this.Size(size).BGColor(Color.white).BorderRadius(size / 2);
            if (child != null) this.Add(child);
        }

    }

}