using System;
using System.Collections.Generic;
using System.Text;

namespace Lap6AdvancedC_
{
   
        class Test
        {
            public static string Name;

            // Static Constructor
            static Test()
            {
                Name = "Initialized in static constructor";
                Console.WriteLine("Static constructor called");
            }

            // Static Method
            public static void Show()
            {
                Console.WriteLine(Name);
            }
        }
    }
