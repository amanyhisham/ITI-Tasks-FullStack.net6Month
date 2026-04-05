using System;
using System.Collections.Generic;
using System.Text;

namespace Lap4_Ds_Alogrithms
{
    public class EmployeeUpdata : IComparable
    {
        static int counter = 1;
        public int age;
        public int ID;
        public double salary;
        public string Dname;
        public DateTime HireDate;

        public EmployeeUpdata (int age, double salary, string Dname, DateTime hireDate)
        {
            this.age = age;
            this.salary = salary;
            this.Dname = Dname;
            HireDate = hireDate;
            ID = counter++;
        }
        public int CompareTo(object obj)
            
        {
            EmployeeUpdata other=(EmployeeUpdata)obj;
            return this.HireDate.CompareTo(other.HireDate);//-1 1 0
        }
        public override string ToString()
        {
            return $"ID:{ID} Age:{age} Salary:{salary} Name:{Dname} HireDate:{HireDate}";
        }
    }
}
