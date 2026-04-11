using System;
using System.Collections.Generic;
using System.Text;

namespace Lap1Advanced_C_
{
    class Person
    {
          
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName //read only
        {
            get 
            {
                return FirstName + " " + LastName;
            }
        }
        public int Age { get; set; }//automation


        private string password;

        public string Password//write only
        {
            set
            {
                password = value;
            }
        }
    }
}
