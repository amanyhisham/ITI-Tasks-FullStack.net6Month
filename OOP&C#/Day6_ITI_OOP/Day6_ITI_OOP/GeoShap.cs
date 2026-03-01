using System;
using System.Collections.Generic;
using System.Text;

namespace Day6_ITI_OOP
{
    abstract class GeoShap
    {//data 0.1
        protected double dim1;
        protected double dim2;
        //setter&getter
        protected void setdim1(double _dim1)
        {
            dim1 = _dim1;
        }
        protected void setdim2(double _dim2)
        {
            dim2 = _dim2;
        }
        public double getdim1() { return dim1; }
        public double getdim2() { return dim2; }
        //cots 0.3
        public GeoShap()
        {
            dim1 = 1;
            dim2 = 1;
            Console.WriteLine("You are in defult cotrs");
        }

        public GeoShap(double _dim1, double _dim2)
        {
            dim1 = _dim1;
            dim2 = _dim2;
            Console.WriteLine("You are  in 2paramter cotrs");
        }
        public GeoShap(double _dim)
        {
            dim1 = dim2 = _dim;//circle and squere

            Console.WriteLine("You are  in 1paramter cotrs");
        }
        public abstract double Area();//to make averide at childe

    }
    class Squara : GeoShap
    {
        public Squara()
        {

        }
        public Squara(int num) : base(num, num)
        {

        }
        public override double Area()
        {
            return dim1 * dim2;
        }
        public void setdim1(double _dim1)//as it squere should equal
        {
            dim1 = dim2 = _dim1;
        }
        public void setdim2(double _dim2)
        {
            dim1 = dim2 = _dim2;
        }
    }
    class Rectangle : GeoShap
    {
        public Rectangle()
        {

        }
        public Rectangle(int num1, int num2) : base(num1, num2)
        {

        }
        public override double Area()
        {
            return dim1 * dim2;
        }

    }
    class Circle : GeoShap
    {
        public Circle()
        {

        }
        public Circle(int num) : base(num, num)
        {

        }
        public override double Area()
        {
            return Math.PI * dim1 * dim2;
        }
        public void setreduisc(double _reduisc)
        {
            dim1=dim2= _reduisc;
        }
    }
    class Triangle : GeoShap
    {
        public Triangle()
        {

        }
        public Triangle(int num1, int num2) : base(num1, num2)
        {

        }
        public override double Area()
        {
            return 0.5 * dim1 * dim2;
        }
    }


}