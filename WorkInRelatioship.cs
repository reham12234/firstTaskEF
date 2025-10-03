using System;
using System.Collections.Generic;

namespace BlazorApp2;

public partial class WorkInRelatioship
{
    public int? WorkingHours { get; set; }

    public int? EmpSsn { get; set; }

    public int? ProjectPnum { get; set; }

    public virtual Employee? EmpSsnNavigation { get; set; }

    public virtual Project? ProjectPnumNavigation { get; set; }
}
