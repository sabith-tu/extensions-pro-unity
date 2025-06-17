using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public class RunTimeUIExample : MonoBehaviour
    {
        Color bgBlack = Color.black.WithA(0.8f),
            bgGrey = Color.grey;

        [ContextMenu("BuildUi")]
        void BuildUi()
        {
            UIDocument uiDoccument = GetComponent<UIDocument>();
            if (uiDoccument == null)
                uiDoccument = gameObject.AddComponent<UIDocument>();
            VisualElement root = uiDoccument.rootVisualElement;
            root.Clear();
            HandleUiLogic(root);
        }

        void HandleUiLogic(VisualElement root)
        {
            root.Add(
                new Div()
                    .FixedSize(1000, 700)
                    .Row()
                    .Expand()
                    .CenterF()
                    .Insert(
                        new Div()
                            .FixedSize(200, 700)
                            .BGColor()
                            .BorderRadius()
                            .BGColor(Color.gray)
                            .Insert(
                                new Scrollable(
                                    spaceBetween: 20,
                                    showScrollBar: false,
                                    elements: new List<VisualElement>
                                    {
                                        MapCard(),
                                        MapCard(),
                                        MapCard(),
                                        MapCard(),
                                        MapCard(),
                                        MapCard(),
                                        MapCard(),
                                    }
                                ).Padding(25)
                            ),
                        new Div().FixedSize(30, 700).BorderRadius(),
                        new Div()
                            .Expand()
                            .BGColor()
                            .BorderRadius()
                            .BGColor(Color.gray)
                            .Padding(25)
                            .Expand()
                            .Insert(
                                new Column(
                                    25,
                                    new Div()
                                        .Expand()
                                        .FixedHeight(50)
                                        .BorderRadius()
                                        .Insert(
                                            new Row(
                                                15,
                                                5,
                                                new Div()
                                                    .Expand(3)
                                                    .FixedHeight(45)
                                                    .BGColor(bgBlack)
                                                    .BorderRadius(),
                                                new Div()
                                                    .Expand(1)
                                                    .FixedHeight(45)
                                                    .BGColor(bgBlack)
                                                    .BorderRadius()
                                            ).CenterF()
                                        ),
                                    new Div().Expand().FixedHeight(340).BGColor().BorderRadius(),
                                    new Div()
                                        .Expand()
                                        .FixedHeight(200)
                                        .BorderRadius()
                                        .Padding(5)
                                        .Insert(
                                            new Column(
                                                5,
                                                GetToggleElement(),
                                                GetToggleElement(),
                                                GetToggleElement()
                                            )
                                        )
                                )
                            )
                    )
            );
        }

        VisualElement GetToggleElement() =>
            new Div()
                .Expand()
                .FixedHeight(60)
                .BGColor(bgBlack)
                .BorderRadius()
                .Insert(
                    new Row(
                        15,
                        25,
                        new Text("Toogle Group Name"),
                        new Div().Expand().FixedHeight(43).BGColor().BorderRadius(),
                        new Div().Expand().FixedHeight(43).BGColor().BorderRadius(),
                        new Div().Expand().FixedHeight(43).BGColor().BorderRadius()
                    ).CenterF()
                );

        VisualElement MapCard() =>
            new Column(
                new Div().Expand().FixedHeight(110).BGColor().BorderRadiusTop(),
                new Div()
                    .Expand()
                    .FixedHeight(40)
                    .BGColor()
                    .BorderRadiusBottom()
                    .BGColor(new Color(0.6f, 0.6f, 0.6f))
            );
    }
}
