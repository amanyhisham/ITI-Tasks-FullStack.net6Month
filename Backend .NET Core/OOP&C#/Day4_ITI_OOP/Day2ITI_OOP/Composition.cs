using System;
using System.Collections.Generic;
using System.Text;

namespace Day2ITI_OOP
{
      class Line
    {   //data object 0.1
        Point start=new Point();
        Point end=new Point();
        //setter&getter 0.2
        public void SetStart(Point _start) { start = _start; }
        public void SetEnd(Point _end) { end = _end; }
        public Point GetStart() { return start; }
        public Point GetEnd() { return end; }
        //constructor 0.3 
        public Line()
        {
            Console.WriteLine("hi no need to inilization x&y it will take zero");

        }
        public Line(int x1,int y1, int x2, int y2)
        {
            start.SetX(x1);
            start.SetY(y1);
            end.SetX(x2);
            end.SetY(y2);
            Console.WriteLine("line 2p values");

        }
        //print 0.4
        public string PrintLine()
        {
            return $"Line start({start.getX()},{start.getY()}),end ({end.getX()},{end.getY()})";
        }
    }
    class Rectangle
    {//data
        Point ul ;
        Point lr ;
        //getter&setter
        public void SetUL(Point _ul) { ul = _ul; }
        public void SetLR(Point _lr) { lr = _lr; }
        public Point GetUL() { return ul; }
        public Point GetLR() { return lr; }
        //construtor
         public  Rectangle (int x1, int y1, int x2, int y2)
        {
            ul = new Point(x1, y1);
            lr = new Point(x2, y2);
            Console.WriteLine("rect 4p ctor");
        }
        //print
        public string PrintRect()
        {
            return $"Rect ul {ul.PrintPoint()} , lr {lr.PrintPoint()} ";
        }

    }
}
