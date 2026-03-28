using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Day2ITI_OOP
{
    class Circle
    {//need point and r
        Point p;
        double radius;
        //setter&getter
        public void SetP1(Point _p) { p = _p; }
        public void SetR2(double _r) { radius = _r; }
        public Point GetP() { return p; }
        public double GetRadius() { return radius; }
        //construtor
        public Circle()
        {
            p = null;
            radius = 0;
            Console.WriteLine("defult construtor");

        }
        public Circle(Point _p, double _r)
        {
            p = _p;
            radius = _r;
            Console.WriteLine("not defult");

        }
        public string PrintCricle()
        {
            return $"Trigle points is p1{p.PrintPoint()} and reduis is: {radius}";
        }


    }
    class Tringle
    {//reference in assiocation
       //data 0.1
        Point p1;
        Point p2;
        Point p3;
        //getter&setter 0.2
        public void SetP1(Point _p1) { p1 = _p1; }
        public void SetP2(Point _p2) { p2 = _p2; }
        public void SetP3(Point _p3) { p3 = _p3; }
        public Point GetP1() { return p1; }
        public Point GetP2() { return p2; }
        public Point GetP3() { return p3; }
        //construtor 0.3
        public Tringle()
        {
              p1=null;
              p2=null;
              p3=null;
            Console.WriteLine("Tringle defult construtor has valu null as value 0 to variable ");
        }
        public Tringle(Point _p1, Point _p2, Point _p3)
        {
            p1 = _p1;
            p2 = _p1;
            p3 = _p3;
           Console.WriteLine("Tringle  3paramter construtor ");

        }

        //print
        public string PrintTringle()
        {
            return $"Trigle points is p1{p1.PrintPoint()},p2{p2.PrintPoint()},p3{p3.PrintPoint()}";
        }

    }
}
