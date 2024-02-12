using Moms250Blazor.Common;
using Microsoft.EntityFrameworkCore;

namespace Moms250Blazor.Data.Repository;

public interface IAssignmentsRepo
{
    Task<List<Assignment>> GetAssignmentsAsync(CancellationToken cancellationToken = default);
    Task<Assignment> GetAssignmentForAssignmentRouteAsync(int ID, CancellationToken cancellationToken = default);
    Task<Assignment> GetAssignmentAsync(int ID, CancellationToken cancellationToken = default);
    Assignment GetAssignment(int ID);
    Task<int> UpdateAssignmentAsync(Assignment a, CancellationToken cancellationToken = default);
    Task<int> UpdateAssignmentFromAssingmentRouteAsync(Assignment a, string username, CancellationToken cancellationToken = default);
    Task<bool> DeleteAssignmentAsync(Assignment a, CancellationToken cancellationToken = default);
    Task<List<MyListItems>> GetMyListItemsApplicantFullNamesAsync(CancellationToken cancellationToken = default);
    Task<List<MyListItems>> GetMyListItemsApplicantTypeAsync(CancellationToken cancellationToken = default);
    Task<List<MyListItems>> GetMyListItemsApplicantStatusAsync(CancellationToken cancellationToken = default);
    Task<List<Assignment>> GetNationalChairReportListAssignmentsAsync(string appStatus, CancellationToken cancellationToken = default);
    List<Assignment> GetNationalChairReportListAssignments(string appStatus, CancellationToken cancellationToken = default);
    Task<List<Assignment>> GetSeniorCoordinatorReportListAssignmentsAsync(SeniorCoordinatorReportType reportType, string param = "", int uId = 0, CancellationToken cancellationToken = default);
    Task<List<Assignment>> GetCoordinatorReportListAssignmentsAsync(CoordinatorReportType reportType, string param = "", string param2 = "", int uId = 0, CancellationToken cancellationToken = default);
}
public class AssignmentsRepo : IAssignmentsRepo
{
    public async Task<List<Assignment>> GetAssignmentsAsync(CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.Assignments.ToListAsync(cancellationToken);
    }
    public async Task<Assignment> GetAssignmentForAssignmentRouteAsync(int ID, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.Assignments.Where(x => x.Id == ID)
            .Include(y => y.Attachments)
            .Include(y => y.Volunteers)
            .ThenInclude(y => y.AppUser)
            .FirstOrDefaultAsync(cancellationToken) ?? new Assignment();
    }
    public async Task<Assignment> GetAssignmentAsync(int ID, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.Assignments.Where(x => x.Id == ID).FirstOrDefaultAsync(cancellationToken) ?? new Assignment();
    }
    public Assignment GetAssignment(int ID)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return db.Assignments.Where(x => x.Id == ID).FirstOrDefault() ?? new Assignment();
    }
    public async Task<int> UpdateAssignmentAsync(Assignment a, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (a.Id == 0)
        {
            db.Assignments.Add(a);
        }
        else if (a.Id != 0)
        {
            //var dbRequest = await db.Assignments.FindAsync(a.Id);
            //_mapper.Map<Assignment>(a, dbRequest);
            db.Assignments.Update(a);
        }
        await db.SaveChangesAsync(cancellationToken);

        return a.Id;
    }
    public async Task<int> UpdateAssignmentFromAssingmentRouteAsync(Assignment a, string userfullname, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (a.Id == 0)
        {
            a.CreatedBy = userfullname;
            a.Created = DateTime.Now;
            db.Assignments.Add(a);
        }
        else if (a.Id != 0)
        {
            var validVolunteers = a.Volunteers.Select(x => x.Id).ToList();
            var missingVolunteers = await db.Volunteers.Where(x => x.AssignmentId == a.Id && !validVolunteers.Contains(x.Id)).ToListAsync(cancellationToken);

            if (missingVolunteers != null && missingVolunteers.Count > 0)
                db.Volunteers.RemoveRange(missingVolunteers);

            var validAttachments = a.Attachments.Select(x => x.Id).ToList();
            var missingAttachments = await db.Attachments.Where(x => x.AssignmentId == a.Id && !validAttachments.Contains(x.Id)).ToListAsync(cancellationToken);

            if (missingAttachments != null && missingAttachments.Count > 0)
                db.Attachments.RemoveRange(missingAttachments);

            a.ModifiedBy = userfullname;
            a.Modified = DateTime.Now;
            db.Assignments.Update(a);
        }
        await db.SaveChangesAsync(cancellationToken);

        return a.Id;
    }
    public async Task<bool> DeleteAssignmentAsync(Assignment a, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (a.Id != 0)
        {
            db.Volunteers.RemoveRange(a.Volunteers);
            db.Attachments.RemoveRange(a.Attachments);
            db.Assignments.Remove(a);
            await db.SaveChangesAsync(cancellationToken);
            return true;
        }
        return false;
    }
    public async Task<List<MyListItems>> GetMyListItemsApplicantFullNamesAsync(CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.Assignments.Select(x => new MyListItems() { S = (x.ApplicantLname + ',' + ' ' + x.ApplicantFname), Text = (x.ApplicantLname + ',' + ' ' + x.ApplicantFname) }).OrderBy(x => x.Text).Distinct().ToListAsync(cancellationToken);
    }
    public async Task<List<MyListItems>> GetMyListItemsApplicantTypeAsync(CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.Assignments.Select(x => new MyListItems() { S = x.ApplicationType, Text = x.ApplicationType ?? "" }).OrderBy(x => x.Text).Distinct().ToListAsync(cancellationToken);
    }
    public async Task<List<MyListItems>> GetMyListItemsApplicantStatusAsync(CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.Assignments.Select(x => new MyListItems() { S = x.ApplicationStatus, Text = x.ApplicationStatus ?? "" }).OrderBy(x => x.Text).Distinct().ToListAsync(cancellationToken);
    }
    public List<Assignment> GetNationalChairReportListAssignments(string appStatus, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return
        [
            .. db.Assignments.Where(x => x.ApplicationStatus == appStatus)
                        .Include(y => y.Volunteers)
                        .ThenInclude(y => y.AppUser),
        ];
    }
    public async Task<List<Assignment>> GetNationalChairReportListAssignmentsAsync(string appStatus, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.Assignments.Where(x => x.ApplicationStatus == appStatus)
            .Include(y => y.Volunteers)
            .ThenInclude(y => y.AppUser)
            //.Select(y => y.)
            .ToListAsync(cancellationToken);
    }
    public async Task<List<Assignment>> GetSeniorCoordinatorReportListAssignmentsAsync(SeniorCoordinatorReportType reportType, string param = "", int uId = 0, CancellationToken cancellationToken = default)
    {
        List<int> assingmentIds = [];
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (reportType == SeniorCoordinatorReportType.assignmentsByCoord)
        {
            if (!string.IsNullOrEmpty(param))
                assingmentIds = await db.Volunteers.Where(y => y.AppUser.ManagerId == param).Select(y => y.AssignmentId).Distinct().ToListAsync(cancellationToken);
            else
                assingmentIds = await db.Assignments.Select(y => y.Id).ToListAsync(cancellationToken);
        }
        else if (reportType == SeniorCoordinatorReportType.assignmentsByVolunteersThenState)
        {
            if (uId > 0 && !string.IsNullOrEmpty(param))
                assingmentIds = await db.Volunteers.Where(y => y.AppUserId == uId && y.AppUser.State == param).Include(y => y.AppUser).Select(y => y.AssignmentId).Distinct().ToListAsync(cancellationToken);
            else if (uId > 0)
                assingmentIds = await db.Volunteers.Where(y => y.AppUserId == uId).Select(y => y.AssignmentId).Distinct().ToListAsync(cancellationToken);
            else if (!string.IsNullOrEmpty(param))
                assingmentIds = await db.Volunteers.Where(y => y.AppUser.State == param).Include(y => y.AppUser).Select(y => y.AssignmentId).Distinct().ToListAsync(cancellationToken);
            else
                assingmentIds = await db.Assignments.Select(y => y.Id).ToListAsync(cancellationToken);
        }
        else if (reportType == SeniorCoordinatorReportType.assignmentsByRequests)
        {
            if (param == "SeniorCoordinatorRequest")
                assingmentIds = await db.Assignments.Where(y => y.SeniorCoordinatorRequest == true).Select(y => y.Id).ToListAsync(cancellationToken);
            else if (param == "CoordinatorRequest")
                assingmentIds = await db.Assignments.Where(y => y.CoordinatorRequest == true).Select(y => y.Id).ToListAsync(cancellationToken);
            else
                assingmentIds = await db.Assignments.Select(y => y.Id).ToListAsync(cancellationToken);
        }
        else
        {
            assingmentIds = await db.Assignments.Select(x => x.Id).ToListAsync(cancellationToken);
        }

        return await db.Assignments.Where(x => assingmentIds.Contains(x.Id))
        .Include(y => y.Volunteers)
        .ThenInclude(y => y.AppUser)
        //.Select(y => y.)
        .ToListAsync(cancellationToken) ?? [];
    }
    public async Task<List<Assignment>> GetCoordinatorReportListAssignmentsAsync(CoordinatorReportType reportType, string param = "", string param2 = "", int uId = 0, CancellationToken cancellationToken = default)
    {
        List<int> assingmentIds = [];
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (reportType == CoordinatorReportType.assignmentsAToZ)
        {
            return await db.Assignments.OrderBy(y => y.ApplicantLname).ThenBy(y => y.ApplicantFname)
            .Include(y => y.Volunteers)
            .ThenInclude(y => y.AppUser)
            //.Select(y => y.)
            .ToListAsync(cancellationToken) ?? [];
        }
        else if (reportType == CoordinatorReportType.assignmentsByAgeBasedOnDateAssigned)
        {
            return await db.Assignments.OrderByDescending(y => y.ApplicationDateAssigned)
            .Include(y => y.Volunteers)
            .ThenInclude(y => y.AppUser)
            //.Select(y => y.)
            .ToListAsync(cancellationToken) ?? [];
        }
        else if (reportType == CoordinatorReportType.assignmentsByStateThenAToZ)
        {
            if (!string.IsNullOrEmpty(param) && !string.IsNullOrEmpty(param2))
                assingmentIds = await db.Assignments.Where(y => y.ApplicantState == param && (y.ApplicantLname + ',' + ' ' + y.ApplicantFname) == param2).Select(y => y.Id).ToListAsync(cancellationToken);
            else if (!string.IsNullOrEmpty(param) && string.IsNullOrEmpty(param2))
                assingmentIds = await db.Assignments.Where(y => y.ApplicantState == param).Select(y => y.Id).ToListAsync(cancellationToken);
            else if (string.IsNullOrEmpty(param) && !string.IsNullOrEmpty(param2))
                assingmentIds = await db.Assignments.Where(y => (y.ApplicantLname + ',' + ' ' + y.ApplicantFname) == param2).Select(y => y.Id).ToListAsync(cancellationToken);
            else
                assingmentIds = await db.Assignments.Select(y => y.Id).ToListAsync(cancellationToken);

            return await db.Assignments.Where(x => assingmentIds.Contains(x.Id)).OrderBy(y => y.ApplicantState).ThenBy(y => (y.ApplicantLname + ',' + ' ' + y.ApplicantFname))
            .Include(y => y.Volunteers)
            .ThenInclude(y => y.AppUser)
            //.Select(y => y.)
            .ToListAsync(cancellationToken) ?? [];
        }
        else if (reportType == CoordinatorReportType.assignmentsByTypeThenStatus)
        {
            if (!string.IsNullOrEmpty(param) && !string.IsNullOrEmpty(param2))
                assingmentIds = await db.Assignments.Where(y => y.ApplicationType == param && y.ApplicationStatus == param2).Select(y => y.Id).ToListAsync(cancellationToken);
            else if (!string.IsNullOrEmpty(param) && string.IsNullOrEmpty(param2))
                assingmentIds = await db.Assignments.Where(y => y.ApplicationType == param).Select(y => y.Id).ToListAsync(cancellationToken);
            else if (string.IsNullOrEmpty(param) && !string.IsNullOrEmpty(param2))
                assingmentIds = await db.Assignments.Where(y => y.ApplicationStatus == param2).Select(y => y.Id).ToListAsync(cancellationToken);
            else
                assingmentIds = await db.Assignments.OrderBy(y => y.ApplicationType).ThenBy(y => y.ApplicationStatus).Select(y => y.Id).ToListAsync(cancellationToken);

            return await db.Assignments.Where(x => assingmentIds.Contains(x.Id)).OrderBy(y => y.ApplicationType).ThenBy(y => y.ApplicationStatus)
            .Include(y => y.Volunteers)
            .ThenInclude(y => y.AppUser)
            //.Select(y => y.)
            .ToListAsync(cancellationToken) ?? [];
        }
        else if (reportType == CoordinatorReportType.assignmentsByMailed)
        {
            return await db.Assignments.OrderByDescending(y => y.DateComplete)
            .Include(y => y.Volunteers)
            .ThenInclude(y => y.AppUser)
            //.Select(y => y.)
            .ToListAsync(cancellationToken) ?? [];
        }
        else if (reportType == CoordinatorReportType.assignmentsByLeadVolunteer)
        {
            if (uId > 0)
                assingmentIds = await db.Volunteers.Where(y => y.AppUserId == uId && y.LeadVolunteer == true).Select(y => y.AssignmentId).Distinct().ToListAsync(cancellationToken);
            else
                assingmentIds = await db.Assignments.Select(y => y.Id).ToListAsync(cancellationToken);
        }
        else if (reportType == CoordinatorReportType.assignmentsByVolunteer)
        {
            if (uId > 0)
                assingmentIds = await db.Volunteers.Where(y => y.AppUserId == uId && y.LeadVolunteer == false).Select(y => y.AssignmentId).Distinct().ToListAsync(cancellationToken);
            else
                assingmentIds = await db.Assignments.Select(y => y.Id).ToListAsync(cancellationToken);
        }
        else if (reportType == CoordinatorReportType.assignmentsByLastUpdate)
        {
            return await db.Assignments.OrderByDescending(y => y.Modified)
            .Include(y => y.Volunteers)
            .ThenInclude(y => y.AppUser)
            //.Select(y => y.)
            .ToListAsync(cancellationToken) ?? [];
        }
        else if (reportType == CoordinatorReportType.assignmentsByMyVolunteers)
        {
            if (!string.IsNullOrEmpty(param))
                assingmentIds = await db.Volunteers.Where(y => y.AppUser.ManagerId == param).Select(y => y.AssignmentId).Distinct().ToListAsync(cancellationToken);
            else
                assingmentIds = await db.Assignments.Select(y => y.Id).ToListAsync(cancellationToken);
        }
        else if (reportType == CoordinatorReportType.assignmentsByChapterContactList)
        {
            return await db.Assignments.OrderByDescending(y => y.LastContactWithChapterDate)
            .Include(y => y.Volunteers)
            .ThenInclude(y => y.AppUser)
            //.Select(y => y.)
            .ToListAsync(cancellationToken) ?? [];
        }
        else
        {
            assingmentIds = await db.Assignments.Select(x => x.Id).ToListAsync(cancellationToken);
        }

        return await db.Assignments.Where(x => assingmentIds.Contains(x.Id))
        .Include(y => y.Volunteers)
        .ThenInclude(y => y.AppUser)
        //.Select(y => y.)
        .ToListAsync(cancellationToken) ?? [];
    }
}
