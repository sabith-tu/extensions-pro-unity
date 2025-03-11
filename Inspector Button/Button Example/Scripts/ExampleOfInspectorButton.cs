using UnityEngine;

namespace SABI
{
    public class ExampleOfInspectorButton : MonoBehaviour
    {
        public enum exampleEnum { Cat, Dog, Rat, Ball }

        [Button]
        private string Button() => " Button return value";

        [Button("Button with custom name")]
        private void ButtonnWithName()
        {
            Debug.Log($" Button with custon name ");
        }

        [Button]
        private void Button_WithIntArgument(int intArgument)
        {
            Debug.Log($" Button intArgument:{intArgument}  ");
        }

        [Button]
        private void Button_WithIntAndStringArgument(int intArgument, string stringArgument)
        {
            Debug.Log($" Button intArgument:{intArgument} stringArgument:{stringArgument} ");
        }

        [Button]
        private void Button_WithEnumArgument(exampleEnum enumArgument) =>
            Debug.Log($" Button intArgument:{enumArgument}  ");

        [Button(bgColor: "#FFFF00", textColor: "#000000")]
        private void ButtonWithColor() => Debug.Log($" Button ");

        [Button(height: 70)]
        private void ButtonWithCustomHeight() => Debug.Log($" ButtonWithCustomHeight ");

        [Button(width: 200)]
        private void ButtonWithCustomWidth() => Debug.Log($" ButtonWithCustomWidth ");

        [Button(
            height: 100,
            bgColor: "#FF0000",
             bgColor2: "#FFFFFF",
            textColor: "#FFFFFF"
        )]
        private void ButtonWithGradient() => Debug.Log($" Button With Gradient ");

        [Button(groupTag: "GroupA")]
        private string ButtonGroupA1() => " 1st Button og group A";

        [Button(groupTag: "GroupA")]
        private string ButtonGroupA2() => " 2nd Button og group A";

        [Button(groupTag: "GroupA")]
        private string ButtonGroupA3() => " 3rd Button og group A";

        [Button(groupTag: "GroupB")]
        private string ButtonGroupB1() => " 1st Button og group B";

        [Button(groupTag: "GroupB")]
        private string ButtonGroupB2() => " 2nd Button og group B";

        [Button(
            customName: "Hover",
            height: 50, bgColor: "#FFFFFF",
            textSize: 20,
            textColor: "#FF0000",
            hover_height: 80,
            hover_bgColor: "#000000",
            hover_textSize: 30,
            hover_textColor: "#FF0000"
        )]
        private void ButtonWithHoverAnimation() => Debug.Log($" Button With Hover Animation ");
    }
}



