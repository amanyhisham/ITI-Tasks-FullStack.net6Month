using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structer_Day1_Lap1
{
    public class Employee
    {
        public int ID;
        public int Age;
        public double salary;
        public string Dname;
         public Employee(int iD, int age, double salary, string dname)
        {
            this.ID = iD;
            this.Age = age;
            this.salary = salary;
            this.Dname = dname;
        }
        public override string ToString()
        {
            return $"ID: {ID}, Age {Age} , Salary: {salary}, Department: {Dname}";
        }
    }
}
