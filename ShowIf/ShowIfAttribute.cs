using UnityEngine;
namespace SABI
{
    public class ShowIfAttribute : PropertyAttribute
    {
        public string boolean;

        public ShowIfAttribute(string boolean)
        {
            this.boolean = boolean;
        }
    }
}