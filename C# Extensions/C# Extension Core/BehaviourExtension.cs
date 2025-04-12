using UnityEngine;

namespace SABI
{
    public static class BehaviourExtension
    {
        public static Behaviour EnableBehaviourIfDisabled(this Behaviour behaviour)
        {
            if (!behaviour.enabled)
                behaviour.enabled = true;
            return behaviour;
        }

        public static Behaviour DisableBehaviourIfEnabled(this Behaviour behaviour)
        {
            if (behaviour.enabled)
                behaviour.enabled = false;
            return behaviour;
        }

        public static Behaviour EnableBehaviour(this Behaviour behaviour)
        {
            behaviour.enabled = true;
            return behaviour;
        }

        public static Behaviour DisableBehaviour(this Behaviour behaviour)
        {
            behaviour.enabled = false;
            return behaviour;
        }

        public static Behaviour ToggleBehaviour(this Behaviour behaviour)
        {
            behaviour.enabled = !behaviour.enabled;
            return behaviour;
        }
    }
}
