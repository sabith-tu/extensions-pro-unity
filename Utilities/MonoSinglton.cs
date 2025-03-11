using UnityEngine;
namespace SABI
{
    public class MonoSinglton<T> : MonoBehaviour
    where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                // if (_instance == null)
                // {
                //     GameObject singletonObject = new GameObject();
                //     _instance = singletonObject.AddComponent<T>();
                //     singletonObject.name = typeof(T).ToString() + " (Singleton)";
                // }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                // DontDestroyOnLoad(gameObject);
            }
            else
            {
                // Destroy(gameObject);
                Debug.LogError("Singleton : Multiple instance found");
            }
        }
    }
}