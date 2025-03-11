using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public class Scrollable : Div
    {
        public Scrollable(List<VisualElement> elements = null, float spaceBetween = 0, float spaceAround = 0, bool showScrollBar = true, ScrollViewMode scrollViewMode = ScrollViewMode.Vertical)
        {
            if (elements == null || elements.Count == 0) return;
            float minHeightAround = scrollViewMode == ScrollViewMode.Vertical ? spaceAround : 0;
            float minWidthAround = scrollViewMode == ScrollViewMode.Vertical ? 0 : spaceAround;
            float minHeightBetween = scrollViewMode == ScrollViewMode.Vertical ? spaceBetween : 0;
            float minWidthBetween = scrollViewMode == ScrollViewMode.Vertical ? 0 : spaceBetween;

            ScrollView scrollView = new ScrollView(scrollViewMode);

            scrollView.Add(new VisualElement().MinWidth(minWidthAround).MinHeight(minHeightAround));
            for (int i = 0; i < elements.Count; i++)
            {
                scrollView.Add(elements[i]);
                if (i < elements.Count - 1) scrollView.Add(new VisualElement().MinWidth(minWidthBetween).MinHeight(minHeightBetween));
            }
            if (!showScrollBar)
            {
                scrollView.verticalScrollerVisibility = ScrollerVisibility.Hidden;
                scrollView.horizontalScrollerVisibility = ScrollerVisibility.Hidden;
            }
            scrollView.Add(new VisualElement().MinWidth(minWidthAround).MinHeight(minHeightAround));
            this.Add(scrollView);
        }
        // ---------------------------------------------------------------------------------------------
        public Scrollable(params VisualElement[] elements) : this(elements.ToList()) { }
        public Scrollable(float spaceBetween, params VisualElement[] elements) : this(elements.ToList(), spaceBetween: spaceBetween) { }
        public Scrollable(float spaceBetween, float spaceAround, params VisualElement[] elements) : this(elements.ToList(), spaceBetween: spaceBetween, spaceAround: spaceAround) { }
    }

}
