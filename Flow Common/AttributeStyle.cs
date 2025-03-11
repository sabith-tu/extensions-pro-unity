using UnityEngine;
using UnityEngine.UIElements;
// TODO: Cursor, FontAset, Gradient, TextColor2

namespace SABI
{
    public class AttributeStyle
    {
        public float? width;
        public float? height;
        public Color? bgColor;
        public Color? bgColor2;
        public float? margin;
        public float? padding;
        public float? borderRadius;
        public float? borderWidth;
        public Color? borderColor;
        public Color? borderColor2;
        public float? opacity;
        public float? rotation;
        public string tooltip;
        public float? textSize;
        public Color? textColor;
        public Color? textColor2;
        public Color? textOutlineColor;
        public float? textOutlineWidth;
        public bool boldText;
        public bool italicText;
        public TextAnchor? textAlign;
        public float textLetterSpacing;
        public float textWordSpacing;
        public TextOverflow? textOverflow;

        public AttributeStyle(
            float width = -1,
            float height = -1,
            string bgColor = null,
            string bgColor2 = null,
            float margin = -1,
            float padding = -1,
            float borderRadius = -1,
            float borderWidth = -1,
            string borderColor = null,
            string borderColor2 = null,
            float opacity = -1,
            float rotation = -1,
            string tooltip = null,
            float textSize = -1,
            string textColor = null,
            string textColor2 = null,
            string textOutlineColor = null,
            float textOutlineWidth = -1,
            bool boldText = false,
            bool italicText = false,
            TextAnchor textAlign = TextAnchor.MiddleCenter,
            float textLetterSpacing = -1,
            float textWordSpacing = -1,
            TextOverflow textOverflow = TextOverflow.Ellipsis
        )
        {
            this.width = width == -1 ? null : width;
            this.height = height == -1 ? null : height;
            if (bgColor != null)
            {
                ColorUtility.TryParseHtmlString(bgColor, out var buttonColor);
                this.bgColor = buttonColor;
            }
            if (bgColor2 != null)
            {
                ColorUtility.TryParseHtmlString(bgColor2, out var buttonColor2);
                this.bgColor2 = buttonColor2;
            }
            this.margin = margin == -1 ? null : margin;
            this.padding = padding == -1 ? null : padding;
            this.borderRadius = borderRadius == -1 ? null : borderRadius;
            this.borderWidth = borderWidth == -1 ? null : borderWidth;
            if (borderColor != null)
            {
                ColorUtility.TryParseHtmlString(borderColor, out var parsedBorderColor);
                this.borderColor = parsedBorderColor;
            }
            if (borderColor2 != null)
            {
                ColorUtility.TryParseHtmlString(borderColor2, out var parsedBorderColor2);
                this.borderColor2 = parsedBorderColor2;
            }
            this.opacity = opacity == -1 ? null : opacity;
            this.rotation = rotation == -1 ? null : rotation;
            this.tooltip = tooltip;
            this.textSize = textSize == -1 ? null : textSize;
            if (textColor != null)
            {
                ColorUtility.TryParseHtmlString(textColor, out var parsedTextColor);
                this.textColor = parsedTextColor;
            }
            if (textColor2 != null)
            {
                ColorUtility.TryParseHtmlString(textColor2, out var parsedTextColor2);
                this.textColor2 = parsedTextColor2;
            }
            if (textOutlineColor != null)
            {
                ColorUtility.TryParseHtmlString(textOutlineColor, out var outlineColor);
                this.textOutlineColor = outlineColor;
            }
            this.textOutlineWidth = textOutlineWidth == -1 ? null : textOutlineWidth;
            this.boldText = boldText;
            this.italicText = italicText;
            this.textAlign = textAlign;
            this.textLetterSpacing = textLetterSpacing;
            this.textWordSpacing = textWordSpacing;
            this.textOverflow = textOverflow;
        }
    }
}