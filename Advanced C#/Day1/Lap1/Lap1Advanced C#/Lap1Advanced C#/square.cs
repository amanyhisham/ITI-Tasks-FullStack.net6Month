using System;
using System.Collections.Generic;
using System.Text;

namespace Lap1Advanced_C_
{
    class Square : IShape, IColor
    {
        public double SideLength { get; set; }
        private string color;

        public Square(double sideLength, string color)
        {
            SideLength = sideLength;
            this.color = color;
        }

        public double CalculateArea() => SideLength * SideLength;
        public double CalculatePerimeter() => 4 * SideLength;
        public string GetColor() => color;
    }
}
