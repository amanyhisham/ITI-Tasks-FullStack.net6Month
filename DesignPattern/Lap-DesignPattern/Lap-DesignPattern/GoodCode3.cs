using System;
using System.Collections.Generic;
using System.Text;

namespace Lap_DesignPattern
{
    interface INotification
    {
        void Send();
    }

    class EmailNotification : INotification
    {
        public void Send() => Console.WriteLine("Send Email");
    }

    class SmsNotification : INotification
    {
        public void Send() => Console.WriteLine("Send SMS");
    }

    class NotificationFactory
    {
        public static INotification Create(string type)
        {
            if (type == "Email")
                return new EmailNotification();
            else
                return new SmsNotification();
        }
    }
    //solution
    //Separated object creation into a factory
    //Improved scalability
}
