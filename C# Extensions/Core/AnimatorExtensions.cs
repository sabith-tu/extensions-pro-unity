using System.Collections.Generic;
using UnityEngine;

//TODO: Improve Set Animator
namespace SABI
{
    public static class AnimatorExtensions
    {
        // private static Dictionary<int, string> currentAnimationStates = new Dictionary<int, string>();

        public static Animator SetAnimation(
            this Animator animator,
            string animationStateName,
            // bool canPlaySameAnimation = false,
            int layer = 0,
            float transitionDuration = 0.2f
        )
        {
            // if (
            //     canPlaySameAnimation
            //     || !currentAnimationStates.TryGetValue(layer, out string currentState)
            //     || currentState != animationStateName
            // )
            {
                animator.CrossFade(animationStateName, transitionDuration, layer);
                // currentAnimationStates[layer] = animationStateName;
            }
            return animator;
        }

        public static Animator PlayAnimation(
            this Animator animator,
            string animationStateName,
            int layer = 0
        )
        {
            animator.Play(animationStateName, layer);
            // currentAnimationStates[layer] = animationStateName;
            return animator;
        }

        public static string GetCurrentAnimationState(this Animator animator, int layer = 0)
        {
            // if (currentAnimationStates.TryGetValue(layer, out string state))
            //     return state;
            return string.Empty;
        }

        public static Animator PauseAnimations(this Animator animator)
        {
            animator.speed = 0f;
            return animator;
        }

        public static Animator ResumeAnimations(this Animator animator)
        {
            animator.speed = 1f;
            return animator;
        }
    }
}