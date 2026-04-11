using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;


namespace Lap1Advanced_C_
{
    internal class PhoneBook
    {
        private Dictionary<int, string> phoneToName = new Dictionary<int, string>();
        private Dictionary<string, int> nameToPhone = new Dictionary<string, int>();

        public string this[int phone]
        {
            get
            {
                return phoneToName[phone];//string ;
            }
            set
            {
                if (phone <= 0)
                    throw new Exception("Invalid phone number");

                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Invalid name");
                phoneToName[phone] = value;
                nameToPhone[value] = phone;
            }
        }

        public int this[string name]
        {
            get
            {
                return nameToPhone[name];//int phone  ;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new Exception("Invalid name");

                if (value <= 0)
                    throw new Exception("Invalid phone number");

                nameToPhone[name] = value;
                phoneToName[value] = name;
            }
        }
    }
}
