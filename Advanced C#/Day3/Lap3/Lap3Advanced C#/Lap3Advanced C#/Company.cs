using System;
using System.Collections.Generic;
using System.Text;

namespace Lap3Advanced_C_
{
    class Company
    {
        public string Name { get; set; }
        public float Budget { get; private set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Company(string name, float budget)
        {
            Name = name;
            Budget = budget;
        }

         public void AddEmployee(Employee emp)
        {
            Employees.Add(emp);
            emp.Event_SalaryIncreased += OnSalaryIncreased;
        }

        private void OnSalaryIncreased(float amount)
        {
            Budget -= amount;
            Console.WriteLine($"{Name} budget decreased by {amount}, remaining budget: {Budget}");
        }

        //Delegate + task2
        public delegate bool EmployeeFilter(Employee emp);
        public List<Employee> FilterEmployees(EmployeeFilter filter)
        {
            List<Employee> result = new List<Employee>();

            foreach (var emp in Employees)
            {
                if (filter(emp)) 
                {
                    result.Add(emp);
                }
            }

            return result;
        }
    }
}
