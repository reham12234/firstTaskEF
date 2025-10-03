﻿using System;
using System.Collections.Generic;

namespace BlazorApp2;

public partial class Department
{
    public int Dnum { get; set; }

    public string? Dname { get; set; }

    public int? EmpSsn { get; set; }

    public virtual Employee? EmpSsnNavigation { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
