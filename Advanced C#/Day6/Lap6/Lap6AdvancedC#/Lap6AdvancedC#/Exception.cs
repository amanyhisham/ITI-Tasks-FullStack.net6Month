using System;
using System.Collections.Generic;
using System.Text;

namespace Lap6AdvancedC_
{
      class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message)
        {
        }

    }


    public class StudentService
    {
        public void CheckAge(int age)
        {
            if (age < 18)
            {
                throw new InvalidAgeException("Age must be 18 or more");
            }

            Console.WriteLine("Valid Age");
        }
    }

}
