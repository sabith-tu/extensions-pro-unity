using UnityEngine;
namespace SABI
{
    public class AutoDestroyableInGivenTime : MonoBehaviour
    {
        float autoDestroyTime = 0;

        public void SetTime(float value)
        {
            autoDestroyTime = value;
        }

        void Start()
        {
            Destroy(gameObject, autoDestroyTime);
        }
    }
}