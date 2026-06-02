using System;
using System.Collections.Generic;
using System.Text;

namespace EFLap2
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        // Relationship
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
