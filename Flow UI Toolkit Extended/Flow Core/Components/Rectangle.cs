using UnityEngine;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public class Rectangle : Div
    {
        public Rectangle(Length width, Length height, Div child = null)
        {
            this.Size(width, height).BGColor(Color.white);
            if (child != null) this.Add(child);
        }
        // ---------------------------------------------------------------------------------------------
        public Rectangle(Length? size = null, Div child = null) : this(size ?? 50, size ?? 50, child) { }
    }
}