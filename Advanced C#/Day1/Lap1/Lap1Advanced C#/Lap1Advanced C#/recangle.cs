using System;
using System.Collections.Generic;
using System.Text;
 namespace Lap1Advanced_C_
{

    class Rectangle : IShape, IColor
    {
        public double Width { get; set; }
        public double Height { get; set; }
        private string color;

        public Rectangle(double width, double height, string color)
        {
            Width = width;
            Height = height;
            this.color = color;
        }

        public double CalculateArea()
        {
            return Width * Height;
        }

        public double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public string GetColor()
        {
            return color;
        }
    }
    
     
}
