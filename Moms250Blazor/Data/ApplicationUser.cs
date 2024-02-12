using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moms250Blazor.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Volunteers = new HashSet<Volunteer>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationUserId { get; set; }
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? State { get; set; }
        public bool Active { get; set; } = true;
        public string? ManagerId { get; set; }
        public bool Volunteer { get; set; } = true;
        public bool Coordinator { get; set; } = false;
        public bool SeniorCoordinator { get; set; } = false;
        public bool NationalChair { get; set; } = false;
        public string? Residence { get; set; }
        public bool AppAngel { get; set; } = false;
        public string? Comments { get; set; }
        public string? PreferencesAndSkills { get; set; }
        public string? Chapter { get; set; }
        public int RadzenDataGridPageSizePref { get; set; } = 15;
        public DateTime Created { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "System";
        public DateTime Modified { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = "System";
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}
