using System.Collections.Generic;
using UnityEngine.UIElements;
namespace SABI.Flow
{
    public static class VEExtensions_Animations
    {

        #region Default Values
        const float AnimationDelay = 0;
        const float AnimationDuration = 0.2f;
        const EasingMode AnimationTimingFunction = EasingMode.EaseInOutSine;
        const string AnimationTransitionProperty = "all";
        #endregion

        #region Animation

        public static T TransitionDelay<T>(this T element, StyleList<TimeValue>? delay = null)
            where T : VisualElement
        {
            element.style.transitionDelay =
                delay ?? new List<TimeValue> { new TimeValue(1, TimeUnit.Second) };
            return element;
        }

        public static T TransitionDelay<T>(this T element, float delay)
            where T : VisualElement
        {
            element.style.transitionDelay = new List<TimeValue>
        {
            new TimeValue(delay, TimeUnit.Second),
        };
            return element;
        }

        public static T TransitionDuration<T>(this T element, StyleList<TimeValue>? duration = null)
            where T : VisualElement
        {
            element.style.transitionDuration =
                duration ?? new List<TimeValue> { new TimeValue(0.2f, TimeUnit.Second) };

            return element;
        }

        public static T TransitionDuration<T>(this T element, float duration)
            where T : VisualElement
        {
            element.style.transitionDuration = new List<TimeValue>
        {
            new TimeValue(duration, TimeUnit.Second),
        };

            return element;
        }

        public static T TransitionProperty<T>(
            this T element,
            StyleList<StylePropertyName>? property = null
        )
            where T : VisualElement
        {
            element.style.transitionProperty =
                property ?? new List<StylePropertyName> { new StylePropertyName("all") };
            return element;
        }

        public static T TransitionProperty<T>(this T element, string property)
            where T : VisualElement
        {
            element.style.transitionProperty = new List<StylePropertyName>
        {
            new StylePropertyName(property),
        };
            return element;
        }

        public static T TransitionTimingFunction<T>(this T element)
            where T : VisualElement
        {
            element.style.transitionTimingFunction = new List<EasingFunction>
        {
            EasingMode.EaseInOutSine,
        };
            return element;
        }

        public static T TransitionTimingFunction<T>(this T element, EasingMode timingFunction)
            where T : VisualElement
        {
            element.style.transitionTimingFunction = new List<EasingFunction> { timingFunction };
            return element;
        }

        public static T Animate<T>(
            this T element,
            float duration = AnimationDuration,
            EasingMode easingMode = AnimationTimingFunction,
            float delay = AnimationDelay,
            string property = AnimationTransitionProperty
        )
            where T : VisualElement =>
            element
                .TransitionDelay(delay)
                .TransitionDuration(duration)
                .TransitionProperty(property)
                .TransitionTimingFunction(easingMode);
        #endregion

    }
}