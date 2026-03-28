using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Security.Principal;
using System.Text;

namespace Day5_ITI_OOP
{
    class Complex
    {
        //data 0.1
        int real;
        int img;

        //getter&setter
        public void SetReal(int _real)
        {
            this.real = _real;
        }
        public int GetReal()
        {
            return this.real;
        }
        public void SetImg(int _img)
        {
            this.img = _img;
        }
        public int GetImg()
        {
            return img;
        }
        //print
        public string Print()
        {
            return $"{this.real}+{this.img}i";
        }
        //construtors
        public Complex()
        {
            real = 3;
            img = 4;
            Console.WriteLine("Hello inside ctor defult");

        }
        public Complex(int _real, int _img)
        {

            real = _real;
            img = _img;
            Console.WriteLine("Hello inside ctor have 2paramter");
        }
        public Complex(int num)
        {

            real = real = num;

            Console.WriteLine("Hello inside ctor have 1paramter");
        }
        //add two complex
        public Complex add(Complex c1, Complex c2)
        {
            Complex reasult = new Complex();
            reasult.real = c1.real + c2.real;
            reasult.img = c1.img + c2.img;
            return reasult;

        }
        //opertor c1+c2 vaild at file program
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex reasult = new Complex();
            reasult.real = c1.real + c2.real;
            reasult.img = c1.img + c2.img;
            return reasult;


        }
        //c1+10
        public static Complex operator +(Complex c1, int num)
        {
            Complex reasult = new Complex();
            reasult.real = c1.real + num;
            reasult.img = c1.img;
            return reasult;




        }

        //10+c2
        
        public static Complex operator +(int num, Complex c2)
        {
            Complex reasult = new Complex();
            reasult.real = num+c2.real;
            reasult.img = c2.img;
            return reasult;




        }
        public static bool operator ==(Complex c1, Complex c2)
        {  
            return c1.real == c2.real && c1.img == c2.img;

        }
        public static bool operator !=(Complex c1, Complex c2)
        {
            return c1.real != c2.real && c1.img != c2.img;

        }
       // Print c1 =3+5i
        public override string ToString()
        {
            return $"{real}+{img}i";
        }

    }
}
