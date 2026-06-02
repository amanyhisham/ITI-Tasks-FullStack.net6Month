using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeSystem
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }

         public string DepartmentName { get; set; }
    }
}
