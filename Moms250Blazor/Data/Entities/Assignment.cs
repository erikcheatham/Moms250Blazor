using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moms250Blazor.Data;

public partial class Assignment
{
    public Assignment()
    {
        Attachments = new HashSet<Attachment>();
        Volunteers = new HashSet<Volunteer>();
    }

    public int Id { get; set; }
    public string? ApplicantFullName { get; set; }
    public string? ApplicantFname { get; set; }
    public string? ApplicantLname { get; set; }
    public string? ApplicantState { get; set; }
    public string? ApplicantChapter { get; set; }
    public string? ApplicationType { get; set; }
    public string? ApplicationStatus { get; set; }
    public DateTime? ApplicationDateAssigned { get; set; }
    public string? ChapterContact { get; set; }
    public bool? Registrar { get; set; }
    public string? ChapterContactEmail { get; set; }
    public string? VerifyingGenie { get; set; }
    public DateTime? FirstReview { get; set; }
    public DateTime? DateOfLastAirletter { get; set; }

    [NotMapped]
    public string? LeadVolunteers
    {
        get
        {
            return string.Join<string?>('|', Volunteers.Where(x => x.LeadVolunteer == true).Select(p => p.AppUser.FullName).ToList()) ?? "";
        }
    }

    [NotMapped]
    public string? VolunteerState
    {
        get
        {
            return string.Join<string?>('|', Volunteers.Select(p => p.AppUser.State).Distinct().OrderBy(x => x).ToList()) ?? "";
        }
    }

    [NotMapped]
    public string? VolunteerFullNames
    {
        get
        {
            return string.Join<string?>('|', Volunteers.Where(x => x.LeadVolunteer == false).Select(p => p.AppUser.FullName).ToList()) ?? "";
        }
    }
    public DateTime? ResponseDate { get; set; }
    public DateTime? DateComplete { get; set; }
    public bool? NcupdateRequested { get; set; }
    public bool? HelpRequest { get; set; }
    public bool? ReassignmentRequest { get; set; }
    public bool? Aaarequest { get; set; }
    public bool? Artrequest { get; set; }
    public bool? SeniorCoordinatorRequest { get; set; }
    public bool? CoordinatorRequest { get; set; }
    public bool? ReturnRequest { get; set; }
    public bool? DocReceived { get; set; }
    public bool? PermissionLetter { get; set; }
    public string? SelectedCoordinator { get; set; }
    public string? StateProblem { get; set; }
    public string? Notes { get; set; }
    public DateTime? LastContactWithChapterDate { get; set; }
    public string? MemberInitials { get; set; }
    public bool? VolunteerContactChapter { get; set; }
    public bool? SpecialTeamRequest { get; set; }
    public string? PatriotNumber { get; set; }
    public string? PatriotName { get; set; }
    public bool? NewChildOfPatriot { get; set; }
    public bool? NewPatriot { get; set; }
    public bool? Correction { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = "System";
    public DateTime Modified { get; set; } = DateTime.Now;
    public string ModifiedBy { get; set; } = "System";

    public virtual ICollection<Attachment> Attachments { get; set; }
    public virtual ICollection<Volunteer> Volunteers { get; set; }
}
