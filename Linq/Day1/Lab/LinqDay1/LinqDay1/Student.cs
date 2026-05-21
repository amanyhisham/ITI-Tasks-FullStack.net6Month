using System;
using System.Collections.Generic;
using System.Text;

namespace Day1Linq
{
    public class Student
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Subject[] subjects { get; set; }
    }
}
