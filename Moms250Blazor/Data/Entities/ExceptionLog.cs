using System;
using System.Collections.Generic;

namespace Moms250Blazor.Data;
public partial class ExceptionLog
{
    public int Id { get; set; }
    public string? Message { get; set; }
    public string? StackTrace { get; set; }
    public string? Object { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = "System";
    public DateTime Modified { get; set; } = DateTime.Now;
    public string ModifiedBy { get; set; } = "System";
}