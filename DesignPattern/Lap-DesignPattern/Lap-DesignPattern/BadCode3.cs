using System;
using System.Collections.Generic;
using System.Text;

namespace Lap_DesignPattern
{
    class Notification
    {
        public void Send(string type)
        {
            if (type == "Email")
                Console.WriteLine("Send Email");
            else if (type == "SMS")
                Console.WriteLine("Send SMS");
        }
    }
    //problem
    //Class has multiple responsibilities
    //Hard to extend with new types

}
