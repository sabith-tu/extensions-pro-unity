using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public class SmartPhone : EditorWindow
    {
        [MenuItem("Window/FlowExample/TestEditor")]
        public static void ShowEditorWindow()
        {
            GetWindow<SmartPhone>();
        }

        public void CreateGUI()
        {
            rootVisualElement.Add(
                new Div(
                    new Column(new List<VisualElement> { MicroPhoneAndCamera(), Screen(), NavButtons() }).Expand()
                )
            .Expand()
            .Border()
            .Margin(50).BGColor(.1f)
            );
        }

        private static Div Screen()
        {
            return new Div(
                new Scrollable(
                    showScrollBar: false,
                    spaceBetween: 15,
                // elements: FlowUtil.GenarateListOfRectangles(500, Length.Percent(100), 300)
                elements: FlowUtil.GenarateListOfVisualElement(new Rectangle(Length.Percent(100), 200).Border().BorderColor().BGColor(.4f), 500))
                ).Padding()
                .Border()
                .BGColorEditorDefault()
                .MarginLeftRight(10)
                .Expand();
        }

        private static Row MicroPhoneAndCamera()
        {
            return new Row(
                new List<VisualElement>
                {
                new Spacer(),
                new Row(
                    new List<VisualElement>
                    {
                        new Rectangle(75, 10).BorderRadius(5).BorderWidth(2),
                        new Circle(size: 15).BorderWidth(2).NoBGColor().BorderColor(Color.white),
                    },
                    15
                ).CenterF(),
                new Spacer(),
                }
            )
                .CenterF()
                .FixedHeight(50);
        }

        private static Row NavButtons()
        {
            return new Row(
                new List<VisualElement>
                {
                new Div()
                    .Size(22)
                    .BGColor(Color.white)
                    .BorderRadiusLeft(11).OnHover((e) => e.Size(33), (e)=> e.Size(20)),
                new Spacer(),
                new Circle(size: 22).BGColor().BorderColor(Color.white).OnHover((e) => e.Size(33), (e)=> e.Size(20)),
                new Spacer(),
                new Rectangle(22, 22).OnHover((e) => e.Size(33), (e)=> e.Size(20)),
                },
                spaceAround: 75
            ).CenterF().FixedHeight(50);
        }

    }
}
