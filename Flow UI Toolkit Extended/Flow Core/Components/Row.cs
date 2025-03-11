using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public class Row : Div
    {
        public Row(List<VisualElement> elements = null, float spaceBetween = 0, float spaceAround = 0, bool fillSize = false)
        {
            if (elements == null || elements.Count == 0) return;
            this.Row();
            if (fillSize) this.Expand();
            Add(new Div().MinWidth(spaceAround));
            for (int i = 0; i < elements.Count; i++)
            {
                Add(elements[i]);
                if (i < elements.Count - 1) Add(fillSize ? new Spacer() : new Div().MinWidth(spaceBetween));
            }
            Add(new Div().MinWidth(spaceAround));
        }
        // ---------------------------------------------------------------------------------------------
        public Row(params VisualElement[] elements) : this(elements.ToList()) { }
        public Row(float spaceBetween, params VisualElement[] elements) : this(elements.ToList(), spaceBetween: spaceBetween) { }
        public Row(float spaceBetween, float spaceAround, params VisualElement[] elements) : this(elements.ToList(), spaceBetween: spaceBetween, spaceAround: spaceAround) { }
        public Row(bool fillSize, params VisualElement[] elements) : this(elements.ToList(), fillSize: fillSize) { }
        public Row(float spaceAround, bool fillSize, params VisualElement[] elements) : this(elements.ToList(), spaceAround: spaceAround, fillSize: fillSize) { }
    }

}
