using System;
using System.Threading;

namespace Lap7_Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Number num = new Number(5);
            Console.WriteLine("--- Part 1: Same Thread ---");

            DateTime start1 = DateTime.Now;  

            num.Factorial();  
            num.Sum();      

            double time1 = (DateTime.Now - start1).TotalSeconds;
            Console.WriteLine($"Total time: {time1:F1} seconds");

            Console.WriteLine();

           
            Console.WriteLine("--- Part 2: Separate Threads ---");

            DateTime start2 = DateTime.Now;  

             Thread t1 = new Thread(num.Factorial);
            Thread t2 = new Thread(num.Sum);

            t1.Start(); 
            t2.Start();  

            t1.Join();  
            t2.Join(); 

            double time2 = (DateTime.Now - start2).TotalSeconds;
            Console.WriteLine($"Total time: {time2:F1} seconds");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}