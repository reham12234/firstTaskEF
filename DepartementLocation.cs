using System;
using System.Collections.Generic;

namespace BlazorApp2;

public partial class DepartementLocation
{
    public string? Locationn { get; set; }

    public int? Dnum { get; set; }

    public virtual Department? DnumNavigation { get; set; }
}
