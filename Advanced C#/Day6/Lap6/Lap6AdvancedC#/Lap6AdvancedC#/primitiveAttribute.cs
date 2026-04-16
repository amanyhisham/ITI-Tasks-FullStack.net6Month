using System;
using System.Collections.Generic;
using System.Text;

namespace Lap6AdvancedC_
{
    public class primitiveAttribute
    {
         
            public static void ShowPrimitiveMetadata()
            {
                Type type = typeof(int);

                Console.WriteLine("Type Name: " + type.Name);
                Console.WriteLine("Full Name: " + type.FullName);
                Console.WriteLine("Is Primitive: " + type.IsPrimitive);
                Console.WriteLine("Is Value Type: " + type.IsValueType);

            }
      }
    
}
