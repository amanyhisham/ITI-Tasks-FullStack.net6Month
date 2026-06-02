using System;
using System.Collections.Generic;
using System.Text;

namespace EFLap2
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationship
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public Instructor HeadInstructor { get; set; }
    }
}
