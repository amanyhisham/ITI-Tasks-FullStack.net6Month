using System;
using System.Collections.Generic;
using System.Text;

namespace Lap3Advanced_C_
{
    public class Employee
    {
        public string Name { get; set; }
        public float Salary { get; private set; }

         public event Action<float> Event_SalaryIncreased;

        public Employee(string name, float salary)
        {
            Name = name;
            Salary = salary;
        }

        public void IncreaseSalary(float amount)
        {
            Salary += amount;
            Console.WriteLine($"{Name} salary increased by {amount}, new salary: {Salary}");
           
            Event_SalaryIncreased?.Invoke(amount);
        }

         
    }
}
