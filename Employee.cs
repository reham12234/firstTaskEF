using System;
using System.Collections.Generic;

namespace BlazorApp2;

public partial class Employee
{
    public int Ssn { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Gender { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public int? Dnum { get; set; }

    public int? SuperId { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();

    public virtual Department? DnumNavigation { get; set; }

    public virtual ICollection<Employee> InverseSuper { get; set; } = new List<Employee>();

    public virtual Employee? Super { get; set; }
}
