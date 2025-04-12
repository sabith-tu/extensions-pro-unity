using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

namespace SABI.Flow
{
    public class Div : VisualElement
    {
        public Div() { }
        // ---------------------------------------------------------------------------------------------
        public Div(Div child)
        {
            if (child != null) this.Add(child);
        }
        // ---------------------------------------------------------------------------------------------
        public Div(VisualElement child)
        {
            if (child != null) this.Add(child);
        }
    }
}