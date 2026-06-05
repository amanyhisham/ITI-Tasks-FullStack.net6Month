using System;
using System.Collections.Generic;
using System.Text;

namespace Lap_DesignPattern
{
    interface IDiscount
    {
        double GetDiscount();
    }

    class StudentDiscount : IDiscount
    {
        public double GetDiscount() => 0.1;
    }

    class VipDiscount : IDiscount
    {
        public double GetDiscount() => 0.2;
    }
    //solution
    //Used an interface
//Can extend behavior without modifying existing code
}
