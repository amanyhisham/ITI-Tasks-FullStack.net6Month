using System;
using System.Collections.Generic;
using System.Text;

namespace Day2ITI_OOP
{
     class Complex
    {   //data defination;
        private int real;
        private int img;
        private static int counter=0;
        //getter&setter ;
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
        public static int Getcounter()
        {
            return counter;
        }
        //print with validation
        public string Print()
        {
            if (img > 1 && real != 0)
            {
                return $"{real}+{this.img}i";
            }
            else if (img < -1 && real != 0)
            {
                return $"{real}{this.img}i";
            }
            else if (img == 1 && real != 0)
            {
                return $"{real}+i";
            }
            else if (img == -1 && real != 0)
            {
                return $"{real}-i";
            }
            else if (img == 0 && real != 0)
            {
                return $"{real}";
            }
            /////////
            else if (img > 1 && real == 0)
            {
                return $"{this.img}i";
            }
            else if (img < -1 && real == 0)
            {
                return $"{this.img}i";
            }
            else if (img == 1 && real == 0)
            {
                return $"i";
            }
            else if (img == -1 && real == 0)
            {
                return $"-i";
            }
            else if (img == 0 && real == 0)
            {
                return $"{real}";
            }
            return $"";
        }
        //construtor(3type)
        public Complex()
        {
            counter++;
            real = 3;
            img = 4;
            Console.WriteLine("hello in defult construtor have no parameter");
        }
        public Complex(int _real,int _img)
        {
            counter++;
          this.real =_real ;
           this. img = _img;
            Console.WriteLine("hello in defult construtor have two parameter");
        }
        public Complex(int _num)
        {
            counter++;
            this.real  = this.img = _num;
            Console.WriteLine("hello in defult construtor have one parameter");
        }
        //add complex two number from type complex
        public Complex Add(Complex c1, Complex c2) { 
            Complex res=new Complex();
            res.real = c1.real + c2.real;
            res.img= c1.img + c2.img;
            return res;
        }
    }
}
