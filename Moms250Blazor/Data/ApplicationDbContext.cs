using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moms250Blazor.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public virtual DbSet<Assignment> Assignments { get; set; } = null!;
    public virtual DbSet<Attachment> Attachments { get; set; } = null!;
    public virtual DbSet<AttachmentsForAll> AttachmentsForAlls { get; set; } = null!;
    public virtual DbSet<ExceptionLog> ExceptionLogs { get; set; } = null!;
    public virtual DbSet<State> States { get; set; } = null!;
    public virtual DbSet<Volunteer> Volunteers { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ContextSettings.DBConnection, options => options.EnableRetryOnFailure());
    }
    private void AvoidApplicationUserIdUpdate()
    {
        foreach (EntityEntry ent in this.ChangeTracker.Entries().Where(p => p.State == EntityState.Modified))
        {
            if (ent.ToString().StartsWith("ApplicationUser") || ent.ToString().StartsWith("AspNetUser"))
            {
                ent.Property("ApplicationUserId").IsModified = false;
            }
        }
    }
    public override int SaveChanges()
    {
        AvoidApplicationUserIdUpdate();
        int retVal;
        try
        {
            retVal = base.SaveChanges();
        }
        catch (ValidationException ex)
        {
            StringBuilder sb = new();
            sb.AppendFormat("{0} failed validation\n", ex.ValidationResult.ErrorMessage);
            sb.AppendLine();
            foreach (string mname in ex.ValidationResult.MemberNames)
            {
                sb.AppendFormat("- {0}", mname);
                sb.AppendLine();
            }

            // Add the original exception as the innerException
            throw new ValidationException(string.Format("Entity Validation Failed - errors follow:\n{0}", sb.ToString()), ex);
        }
        //Debugging
        //catch (Exception e)
        //{
        //    e.ToString();
        //    ;
        //}
        return retVal;
    }
    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        AvoidApplicationUserIdUpdate();
        int retVal;
        try
        {
            retVal = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        catch (ValidationException ex)
        {
            StringBuilder sb = new();
            sb.AppendFormat("{0} failed validation\n", ex.ValidationResult.ErrorMessage);
            sb.AppendLine();
            foreach (string mname in ex.ValidationResult.MemberNames)
            {
                sb.AppendFormat("- {0}", mname);
                sb.AppendLine();
            }

            // Add the original exception as the innerException
            throw new ValidationException(string.Format("Entity Validation Failed - errors follow:\n{0}", sb.ToString()), ex);
        }
        return retVal;
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AvoidApplicationUserIdUpdate();
        int retVal;
        try
        {
            retVal = await base.SaveChangesAsync(cancellationToken);
        }
        catch (ValidationException ex)
        {
            StringBuilder sb = new();
            sb.AppendFormat("{0} failed validation\n", ex.ValidationResult.ErrorMessage);
            sb.AppendLine();
            foreach (string mname in ex.ValidationResult.MemberNames)
            {
                sb.AppendFormat("- {0}", mname);
                sb.AppendLine();
            }

            // Add the original exception as the innerException
            throw new ValidationException(string.Format("Entity Validation Failed - errors follow:\n{0}", sb.ToString()), ex);
        }
        return retVal;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<ApplicationUser>()
        //.Property(p => p.ApplicationUserId)
        //.ValueGeneratedOnAdd();

        //modelBuilder.Entity<ApplicationUser>().Ignore("ApplicationUserId");

        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.Property(e => e.Aaarequest).HasColumnName("AAARequest");

            entity.Property(e => e.ApplicantChapter).HasMaxLength(50);

            entity.Property(e => e.ApplicantFullName)
                .HasMaxLength(350)
                .HasColumnName("ApplicantFullName");

            entity.Property(e => e.ApplicantFname)
                .HasMaxLength(150)
                .HasColumnName("ApplicantFName");

            entity.Property(e => e.ApplicantLname)
                .HasMaxLength(150)
                .HasColumnName("ApplicantLName");

            entity.Property(e => e.ApplicantState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.ApplicationStatus).HasMaxLength(50);

            entity.Property(e => e.ApplicationType).HasMaxLength(50);

            entity.Property(e => e.Artrequest).HasColumnName("ARTRequest");

            entity.Property(e => e.ChapterContact).HasMaxLength(150);

            entity.Property(e => e.ChapterContactEmail).HasMaxLength(255);

            entity.Property(e => e.CreatedBy).HasMaxLength(150);

            entity.Property(e => e.DateOfLastAirletter).HasColumnName("DateOfLastAIRLetter");

            entity.Property(e => e.MemberInitials).HasMaxLength(10);

            entity.Property(e => e.ModifiedBy).HasMaxLength(150);

            entity.Property(e => e.NcupdateRequested).HasColumnName("NCUpdateRequested");

            entity.Property(e => e.PatriotName).HasMaxLength(150);

            entity.Property(e => e.PatriotNumber).HasMaxLength(10);

            entity.Property(e => e.VerifyingGenie).HasMaxLength(150);
        });

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);

            entity.Property(e => e.ModifiedBy).HasMaxLength(150);

            entity.Property(e => e.Name).HasMaxLength(250);

            entity.Property(e => e.Type).HasMaxLength(150);

            entity.HasOne(d => d.Assignment)
                .WithMany(p => p.Attachments)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attachments_To_Assignments");
        });

        modelBuilder.Entity<AttachmentsForAll>(entity =>
        {
            entity.ToTable("AttachmentsForAll");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);

            entity.Property(e => e.Group).HasMaxLength(250);

            entity.Property(e => e.ModifiedBy).HasMaxLength(150);

            entity.Property(e => e.Name).HasMaxLength(250);

            entity.Property(e => e.Type).HasMaxLength(150);
        });

        modelBuilder.Entity<ExceptionLog>(entity =>
        {
            entity.ToTable("ExceptionLog");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);

            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateAb);

            entity.ToTable("State");

            entity.Property(e => e.StateAb)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.CreatedBy).HasMaxLength(150);

            entity.Property(e => e.ModifiedBy).HasMaxLength(150);

            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Volunteer>(entity =>
        {
            entity.HasIndex(e => e.AppUserId, "idx_AppUserId");

            entity.HasIndex(e => e.AssignmentId, "idx_AssignmentId");

            entity.HasIndex(e => e.LeadVolunteer, "idx_LeadVolunteer");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);

            entity.Property(e => e.ModifiedBy).HasMaxLength(150);

            entity.HasOne(d => d.Assignment)
                .WithMany(p => p.Volunteers)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Volunteers_Assignments");

            entity.HasOne(d => d.AppUser)
                .WithMany(p => p.Volunteers)
                .HasPrincipalKey(d => d.ApplicationUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Volunteers_AppUser");
        });
    }
}
