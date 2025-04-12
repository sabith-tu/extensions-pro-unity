using UnityEngine;

namespace SABI
{
    public class NullValidatorExample : MonoBehaviour
    {
        [SerializeField, NullValidation]
        private Collider myCollider;

        [SerializeField, MinimalNullValidation]
        private Renderer myRenderer;



        
    }
}
