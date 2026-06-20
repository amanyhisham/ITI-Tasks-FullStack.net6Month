using System;
using System.Collections.Generic;

namespace Lap3WebAPI.Models;

public partial class Work
{
    public int? EmpId { get; set; }

    public int? ProjectId { get; set; }

    public int? Hours { get; set; }
}
