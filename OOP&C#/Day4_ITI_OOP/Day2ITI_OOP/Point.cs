using System;
using System.Collections.Generic;
using System.Text;

namespace Day2ITI_OOP
{//General
     class Point
    {
        //data 0.1;
        private int x;
        private int y;

        //getter & setter 0.2
        public void SetX(int _x)
        {
            x = _x;
        }
        public void SetY(int _y)
        {
            y = _y;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        //construtor 0.3
        public Point()
        {
            x = y = 0;
            Console.WriteLine("hello in defult construtor");
        }
        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
            Console.WriteLine("hello in two paramter construtor");
        }
        //print
        public string PrintPoint()
        {
            return $"({x},{y})";

        }

    }
}
