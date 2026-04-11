using System;
using System.Collections.Generic;
using System.Text;

namespace Day1_ITI
{
      class Complex
    {  //Data 0.1
        private int real;
        private int imaginary;
        //setter 0.2
        public void SettReal( int _real)
        {
            this.real= _real;
        }
        public void Settimaginary(int _img)
        {
            this.imaginary = _img;
        }
        //getter 0.2
        public int gettreal()
        {
           return this.real;
        }
        public int getimaginary()
        {
            return this.imaginary;
        }
        //print 0.3
        public string Print()
        {
            if (imaginary > 1 && real != 0)
            {
                return $"{real}+{this.imaginary}i";
            }
            else if(imaginary < -1 && real !=0)
            {
                return $"{real}{this.imaginary}i";
            }
            else if(imaginary == 1 && real != 0)
            {
                return $"{real}+i";
            }
            else if (imaginary == -1 && real != 0)
            {
                return $"{real}-i";
            }
            else if (imaginary == 0 && real != 0)
            {
                return $"{real}";
            }
            /////////
            else if (imaginary > 1 && real == 0)
            {
                return $"{this.imaginary}i";
            }
            else if (imaginary < -1 && real == 0)
            {
                return $"{this.imaginary}i";
            }
            else if (imaginary == 1 && real == 0)
            {
                return $"i";
            }
            else if (imaginary == -1 && real == 0)
            {
                return $"-i";
            }
            else if (imaginary == 0 && real == 0)
            {
                return $"{real}";
            }
            return $"";
        }
        // add 0.4
        public Complex add(Complex c1, Complex c2)
        {
            Complex result = new Complex();
            result.real=c1.real + c2.real;
            result.imaginary = c1.imaginary + c2.imaginary;
            return result ;

        }


    }
}
