using System;
using System.Collections.Generic;
using System.Text;

namespace Day1_ITI
{
      struct Employee
    {
        public int id;
        public string name;
        public int age;
        public int salary;
    }
    class Employee_
    {
        private int id;
        private string name;
        private int age;
        private int salary;
         

        //setter
        public void setId(int _id)
        {
            this.id= _id;
        }
        public void setname(string _name)
        {
            this.name = _name;
        }
        public void setage(int _age)
        {
            this.age = _age;
        }
        public void setsalary(int _salary)
        {
            this.salary = _salary;
        }

        //getter
        public int getid()
        {
            return this.id;
        }
        public string getname()
        {
            return this.name;
        }
        public int getage()
        {
          return  this.age;
        }
        public int getsalary()
        {
          return  this.salary;
        }

        //print
        public string print()
        {
            return $"id :{this.id} and name: {this.name} and salary : {this.salary} :and age :{this.salary}";
        } 
    }
}
