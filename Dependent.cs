using System;
using System.Collections.Generic;

namespace BlazorApp2;

public partial class Dependent
{
    public string Namee { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? BirthDate { get; set; }

    public int? EmpSsn { get; set; }

    public virtual Employee? EmpSsnNavigation { get; set; }
}
