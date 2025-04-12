using System;
using UnityEngine;
using UnityEngine.UIElements;

// TODO: Cursor, FontAset

namespace SABI
{

    public enum ButtonPlacement { Everywhere, Inspector, EditorWindow }
    public enum ButtonUsage { EveryTime, RunTime, EditorTime }

    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonAttribute : Attribute
    {
        public AttributeStyle attributeStyle = new AttributeStyle();
        public AttributeStyle hover_attributeStyle = new AttributeStyle();
        public string customText;
        public string groupTag = "";
        public ButtonPlacement buttonPlacement = ButtonPlacement.Everywhere;
        public ButtonUsage buttonUsage = ButtonUsage.EveryTime;

        public ButtonAttribute(
            string customName = null,
            string groupTag = null,
            ButtonPlacement buttonPlacement = ButtonPlacement.Everywhere,
            ButtonUsage buttonUsage = ButtonUsage.EveryTime,
            // Button Attributes ---------------------------------------------------------------------
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
            // Text Attributes ---------------------------------------------------------------------
            float textSize = -1,
            string textColor = null,
            string textOutlineColor = null,
            float textOutlineWidth = -1,
            bool boldText = false,
            bool italicText = false,
            TextAnchor textAlign = TextAnchor.MiddleCenter,
            float textLetterSpacing = 0,
            float textWordSpacing = 0,
            TextOverflow textOverflow = TextOverflow.Ellipsis,


            // Button hover_Attributes ---------------------------------------------------------------------
            float hover_width = -1,
            float hover_height = -1,
            string hover_bgColor = null,
            string hover_bgColor2 = null,
            float hover_margin = -1,
            float hover_padding = -1,
            float hover_borderRadius = -1,
            float hover_borderWidth = 2,
            string hover_borderColor = null,
            string hover_borderColor2 = null,
            float hover_opacity = -1,
            float hover_rotation = -1,
            string hover_tooltip = null,
            // hover_Text Attributes ---------------------------------------------------------------------
            float hover_textSize = -1,
            string hover_textColor = null,
            string hover_textColor2 = null,
            string hover_textOutlineColor = null,
            float hover_textOutlineWidth = -1,
            bool hover_boldText = true,
            bool hover_italicText = false,
            TextAnchor hover_textAlign = TextAnchor.MiddleCenter,
            float hover_textLetterSpacing = 10,
            float hover_textWordSpacing = 0,
            TextOverflow hover_textOverflow = TextOverflow.Ellipsis
        )
        {
            this.buttonPlacement = buttonPlacement;
            this.buttonUsage = buttonUsage;
            this.groupTag = groupTag;
            this.customText = customName;

            // Normal ------------------------------------------------------------------------------------

            this.attributeStyle.width = width == -1 ? null : width;
            this.attributeStyle.height = height == -1 ? null : height;
            if (bgColor != null)
            {
                ColorUtility.TryParseHtmlString(bgColor, out var buttonColor);
                this.attributeStyle.bgColor = buttonColor;
            }
            if (bgColor2 != null)
            {
                ColorUtility.TryParseHtmlString(bgColor2, out var buttonColor2);
                this.attributeStyle.bgColor2 = buttonColor2;
            }
            this.attributeStyle.margin = margin == -1 ? null : margin;
            this.attributeStyle.padding = padding == -1 ? null : padding;
            this.attributeStyle.borderRadius = borderRadius == -1 ? null : borderRadius;
            this.attributeStyle.borderWidth = borderWidth == -1 ? null : borderWidth;
            if (borderColor != null)
            {
                ColorUtility.TryParseHtmlString(borderColor, out var parsedBorderColor);
                this.attributeStyle.borderColor = parsedBorderColor;
            }
            if (borderColor2 != null)
            {
                ColorUtility.TryParseHtmlString(borderColor2, out var parsedBorderColor2);
                this.attributeStyle.borderColor2 = parsedBorderColor2;
            }
            this.attributeStyle.opacity = opacity == -1 ? null : opacity;
            this.attributeStyle.rotation = rotation == -1 ? null : rotation;
            this.attributeStyle.tooltip = tooltip;
            this.attributeStyle.textSize = textSize == -1 ? null : textSize;
            if (textColor != null)
            {
                ColorUtility.TryParseHtmlString(textColor, out var parsedTextColor);
                this.attributeStyle.textColor = parsedTextColor;
            }
            if (textOutlineColor != null)
            {
                ColorUtility.TryParseHtmlString(textOutlineColor, out var outlineColor);
                this.attributeStyle.textOutlineColor = outlineColor;
            }
            this.attributeStyle.textOutlineWidth = textOutlineWidth == -1 ? null : textOutlineWidth;
            this.attributeStyle.boldText = boldText;
            this.attributeStyle.italicText = italicText;
            this.attributeStyle.textAlign = textAlign;
            this.attributeStyle.textLetterSpacing = textLetterSpacing;
            this.attributeStyle.textWordSpacing = textWordSpacing;
            this.attributeStyle.textOverflow = textOverflow;

            // Hover ------------------------------------------------------------------------------------


            this.hover_attributeStyle.width = hover_width == -1 ? width == -1 ? null : width : hover_width;
            this.hover_attributeStyle.height = hover_height == -1 ? height == -1 ? null : height : hover_height;
            if (hover_bgColor != null)
            {
                ColorUtility.TryParseHtmlString(hover_bgColor, out var parsedButtonColor);
                this.hover_attributeStyle.bgColor = parsedButtonColor;
            }
            this.hover_attributeStyle.margin = hover_margin == -1 ? margin == -1 ? null : margin : hover_margin;
            this.hover_attributeStyle.padding = hover_padding == -1 ? padding == -1 ? null : padding : hover_padding;
            this.hover_attributeStyle.borderRadius = hover_borderRadius == -1 ? borderRadius == -1 ? null : borderRadius : hover_borderRadius;
            this.hover_attributeStyle.borderWidth = hover_borderWidth == -1 ? borderWidth == -1 ? null : borderWidth : hover_borderWidth;
            if (hover_borderColor != null)
            {
                ColorUtility.TryParseHtmlString(hover_borderColor, out var parsedBorderColor);
                this.hover_attributeStyle.borderColor = parsedBorderColor;
            }
            this.hover_attributeStyle.opacity = hover_opacity == -1 ? null : hover_opacity;
            this.hover_attributeStyle.rotation = hover_rotation == -1 ? null : hover_rotation;
            this.hover_attributeStyle.tooltip = hover_tooltip;
            this.hover_attributeStyle.textSize = hover_textSize == -1 ? null : hover_textSize;
            if (hover_textColor != null)
            {
                ColorUtility.TryParseHtmlString(hover_textColor, out var parsedTextColor);
                this.hover_attributeStyle.textColor = parsedTextColor;
            }
            if (hover_textOutlineColor != null)
            {
                ColorUtility.TryParseHtmlString(hover_textOutlineColor, out var parsedOutlineColor);
                this.hover_attributeStyle.textOutlineColor = parsedOutlineColor;
            }
            this.hover_attributeStyle.textOutlineWidth = hover_textOutlineWidth == -1 ? textOutlineWidth == -1 ? null : textOutlineWidth : hover_textOutlineWidth;
            this.hover_attributeStyle.boldText = hover_boldText;
            this.hover_attributeStyle.italicText = hover_italicText;
            this.hover_attributeStyle.textAlign = hover_textAlign;
            this.hover_attributeStyle.textLetterSpacing = hover_textLetterSpacing;
            this.hover_attributeStyle.textWordSpacing = hover_textWordSpacing;
            this.hover_attributeStyle.textOverflow = hover_textOverflow;
        }
    }
}
