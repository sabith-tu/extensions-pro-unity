using UnityEngine;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public class Text : Div
    {
        public Text(Label label) => this.Add(label);

        // ---------------------------------------------------------------------------------------------
        public Text(
            string text,
            float fontSize = 20,
            Color? fontColor = null,
            FontStyle fontStyle = FontStyle.Normal,
            TextAnchor textAnchor = TextAnchor.MiddleCenter,
            TextOverflow textOverflow = TextOverflow.Ellipsis,
            bool wrap = false,
            int letterSpacing = 0
        )
        {
            Add(
                new Label(text)
                    .FontSize(fontSize)
                    .TextColor(fontColor ?? Color.white)
                    .FontStyleAndWeight(fontStyle)
                    .UnityTextAlign(textAnchor)
                    .Overflow(wrap ? Overflow.Visible : Overflow.Hidden)
                    .TextOverflow(textOverflow)
                    .WhiteSpace(wrap ? WhiteSpace.Normal : WhiteSpace.NoWrap)
                    .LetterSpacing(letterSpacing)
            );
        }
    }
}
