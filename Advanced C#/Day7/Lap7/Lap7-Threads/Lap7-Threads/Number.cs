using System;
using System.Threading;   

namespace Lap7_Threads
{
    internal class Number
    {
         private int value;
         
        public Number(int value)
        {
            this.value = value;
        }
        public void Factorial()
        {
            Console.WriteLine("[Factorial] Started... (sleeping 3 seconds)");
            Thread.Sleep(3000);  

            long result = 1;
            for (int i = 1; i <= value; i++)
            {
                result *= i;
            }

            Console.WriteLine($"[Factorial] Result: {value}! = {result}");
        }

 
        public void Sum()
        {
            Console.WriteLine("[Sum] Started...");

            long result = 0;
            for (int i = 1; i <= value; i++)
            {
                result += i;
            }

            Console.WriteLine($"[Sum] Result: sum of 1 to {value} = {result}");
        }
    }
}