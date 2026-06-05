using System;
using System.Collections.Generic;
using System.Text;

namespace Lap_DesignPattern
{
     class Logger
    {
        public Logger() { }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
    //the problem:-
    /*
Multiple instances can be created
Unnecessary memory usage
No control over instance creation*/
}
