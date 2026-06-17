using System;
using System.Collections.Generic;

namespace Lap2WepApI.Models;

public partial class StudentGrade
{
    public string FullName { get; set; } = null!;

    public string? CourseName { get; set; }

    public int? Grade { get; set; }
}
