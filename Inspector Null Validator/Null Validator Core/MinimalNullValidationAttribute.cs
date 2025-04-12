using UnityEngine;

namespace SABI
{
    [System.AttributeUsage(System.AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class MinimalNullValidationAttribute : PropertyAttribute
    {
        public MinimalNullValidationAttribute() { }
    }
}
