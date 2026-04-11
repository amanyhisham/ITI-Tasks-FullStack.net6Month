using System;
using System.Collections.Generic;
using System.Text;

namespace Lap1Advanced_C_
{
    class Circle : IShape, IColor
    {
        public double Radius { get; set; }
        private string color;

        public Circle(double radius, string color)
        {
            Radius = radius;
            this.color = color;
        }

        public double CalculateArea() => Math.PI * Radius * Radius;
        public double CalculatePerimeter() => 2 * Math.PI * Radius;
        public string GetColor() => color;
    }
}
