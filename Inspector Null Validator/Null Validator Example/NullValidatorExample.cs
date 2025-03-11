using UnityEngine;

namespace SABI
{
    public class NullValidatorExample : MonoBehaviour
    {
        [SerializeField, NullValidation]
        private Collider collider;

        [SerializeField, MinimalNullValidation]
        private Renderer renderer;
    }
}
