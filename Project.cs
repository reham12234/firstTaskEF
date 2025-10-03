using System;
using System.Collections.Generic;

namespace BlazorApp2;

public partial class Project
{
    public int Pnumber { get; set; }

    public string? Pname { get; set; }

    public string? Locationn { get; set; }

    public string? City { get; set; }

    public int? Dnum { get; set; }

    public virtual Department? DnumNavigation { get; set; }
}
