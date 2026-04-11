using System;
using System.Collections.Generic;
using System.Text;

namespace Lap_DesignPattern
{
    class Discount
    {
        public double GetDiscount(string type)
        {
            if (type == "Student")
                return 0.1;
            else if (type == "VIP")
                return 0.2;
            else
                return 0;
        }
    }
    /* problem
     * The class must be modified for every new type
Violates Open/Closed Principle*/
}
