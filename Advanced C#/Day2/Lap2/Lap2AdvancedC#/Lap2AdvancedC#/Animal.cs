using System;
using System.Collections.Generic;
using System.Text;

namespace Lap2AdvancedC_
{
    class Animal
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    class Lion : Animal
    {
        public void Roar()
        {
            Console.WriteLine($"{Name} is roaring!");
        }
    }
    class Sparrow : Animal
    {
        public void Fly()
        {
            Console.WriteLine($"{Name} is flying!");
        }
    }
    class Cage<T> where T : Animal
    {
        public List<T> residents = new List<T>();

        public void Arrive(T resident)
        {
            if (resident.Age > 8)
            {
                throw new Exception("Too old!");
            }

            else {
                residents.Add(resident);
                Console.WriteLine("animal added to cage successfully!");


            }

        }

    }
}