using System;
using System.Collections.Generic;
using System.Text;

namespace Lap_DesignPattern
{
    /*
    Solution
      Used a private constructor to prevent external instantiation
      Ensured a single instance using static
     */
    class Logger2
    {
         private static Logger2 instance2;

         private Logger2() { }

         public static Logger2 GetInstance()
        {
            if (instance2 == null)
            {
                instance2 = new Logger2();
            }

            return instance2;
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
