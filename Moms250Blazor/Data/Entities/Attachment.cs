using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moms250Blazor.Data;

public partial class Attachment
{
    public int Id { get; set; }
    public int AssignmentId { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;

    [NotMapped]
    public string Url
    {
        get
        {
            return $"{ContextSettings.CDNUrl}/{Name}";
        }
    }
    public DateTime Created { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = "System";
    public DateTime Modified { get; set; } = DateTime.Now;
    public string ModifiedBy { get; set; } = "System";

    public virtual Assignment Assignment { get; set; } = null!;
}