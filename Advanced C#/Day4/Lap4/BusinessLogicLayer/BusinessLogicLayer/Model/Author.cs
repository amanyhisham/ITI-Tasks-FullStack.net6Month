using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Model
{
    public class Author
    {
        public string Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string address { get; set; }
        public string Phone { get; set; }
        public bool Contract { get; set; }
        public override string ToString()
        {
            return $"authors: Id={Id}, Name={fName} {lName} ";
        }
    }
}
