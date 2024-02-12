using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moms250Blazor.Data;
public partial class Volunteer
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public int AssignmentId { get; set; }
    public DateTime DateAssigned { get; set; }
    public bool LeadVolunteer { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = "System";
    public DateTime Modified { get; set; } = DateTime.Now;
    public string ModifiedBy { get; set; } = "System";

    public virtual ApplicationUser AppUser { get; set; } = null!;
    public virtual Assignment Assignment { get; set; } = null!;
}