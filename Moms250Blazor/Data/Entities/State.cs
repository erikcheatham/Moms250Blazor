using System;
using System.Collections.Generic;

namespace Moms250Blazor.Data;
public partial class State
{
    public string StateAb { get; set; } = null!;
    public string? Name { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = "System";
    public DateTime Modified { get; set; } = DateTime.Now;
    public string ModifiedBy { get; set; } = "System";
}