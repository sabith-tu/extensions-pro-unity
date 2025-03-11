using UnityEngine;

namespace SABI
{
    [System.AttributeUsage(System.AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class NullValidationAttribute : PropertyAttribute
    {
        public string errorMessage;
        public Color color;
        public bool drawHelpBox;
        public UnityEngine.UIElements.HelpBoxMessageType messageType;

        public NullValidationAttribute(
            string errorMessage = "This field cannot be null!",
            string color = "",
            bool drawHelpBox = true,
            UnityEngine.UIElements.HelpBoxMessageType messageType =
                UnityEngine.UIElements.HelpBoxMessageType.Error
        )
        {
            this.errorMessage = errorMessage;
            if (ColorUtility.TryParseHtmlString(color, out Color parsedColor))
                this.color = parsedColor;
            else
                this.color = new Color(0.8f, 0.2f, 0.2f);
            this.drawHelpBox = drawHelpBox;
            this.messageType = messageType;
        }
    }
}
