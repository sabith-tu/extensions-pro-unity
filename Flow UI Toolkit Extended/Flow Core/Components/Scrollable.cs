using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public class Scrollable : Div
    {
        ScrollView scrollView;
        public Scrollable(List<VisualElement> elements = null, float spaceBetween = 0, float spaceAround = 0, bool showScrollBar = true, ScrollViewMode scrollViewMode = ScrollViewMode.Vertical)
        {
            if (elements == null || elements.Count == 0) return;
            float minHeightAround = scrollViewMode == ScrollViewMode.Vertical ? spaceAround : 0;
            float minWidthAround = scrollViewMode == ScrollViewMode.Vertical ? 0 : spaceAround;
            float minHeightBetween = scrollViewMode == ScrollViewMode.Vertical ? spaceBetween : 0;
            float minWidthBetween = scrollViewMode == ScrollViewMode.Vertical ? 0 : spaceBetween;

            scrollView = new ScrollView(scrollViewMode);

            Debug.Log($"[SAB] ScrollView Created");

            scrollView.contentContainer.Add(new VisualElement().MinWidth(minWidthAround).MinHeight(minHeightAround));
            for (int i = 0; i < elements.Count; i++)
            {
                scrollView.contentContainer.Add(elements[i]);
                if (i < elements.Count - 1) scrollView.Add(new VisualElement().MinWidth(minWidthBetween).MinHeight(minHeightBetween));
            }
            if (!showScrollBar)
            {
                scrollView.verticalScrollerVisibility = ScrollerVisibility.Hidden;
                scrollView.horizontalScrollerVisibility = ScrollerVisibility.Hidden;
            }
            scrollView.contentContainer.Add(new VisualElement().MinWidth(minWidthAround).MinHeight(minHeightAround));
            this.Add(scrollView);
        }
        // ---------------------------------------------------------------------------------------------
        public Scrollable(params VisualElement[] elements) : this(elements.ToList()) { }
        public Scrollable(float spaceBetween, params VisualElement[] elements) : this(elements.ToList(), spaceBetween: spaceBetween) { }
        public Scrollable(float spaceBetween, float spaceAround, params VisualElement[] elements) : this(elements.ToList(), spaceBetween: spaceBetween, spaceAround: spaceAround) { }
        // ---------------------------------------------------------------------------------------------
        public Scrollable Insert(VisualElement element)
        {
            scrollView.contentContainer.Add(element);
            return this;
        }

        public Scrollable Insert(List<VisualElement> elements)
        {
            elements.ForEach(element => scrollView.contentContainer.Add(element));
            return this;
        }

        public Scrollable ClearAll()
        {
            scrollView.contentContainer.Clear();
            return this;
        }
    }

}
