using System;
using System.Collections.Generic;
using System.Text;

namespace Lap5AdvancedC
{  class Zoo
    {
        private List<Animal> animals = new List<Animal>();

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        
        public void ShowAnimals()
        {
            foreach (var a in animals)
            {
                Console.WriteLine(a.Name);
            }
        }
    }
}
