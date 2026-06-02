using System;
using System.Collections.Generic;
using System.Text;

namespace EFLap2
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double? Grade { get; set; }

        // Relationship
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
