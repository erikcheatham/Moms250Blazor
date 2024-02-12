using Moms250Blazor.Common;
using Microsoft.EntityFrameworkCore;

namespace Moms250Blazor.Data.Repository;
public interface IVolunteersRepo
{
    Task<List<Volunteer>> GetVolunteersAsync(CancellationToken cancellationToken = default);
    Task<Volunteer> GetVolunteerAsync(int ID, CancellationToken cancellationToken = default);
    Volunteer GetVolunteer(int ID);
    Task<int> UpdateVolunteerAsync(Volunteer a, CancellationToken cancellationToken = default);
    Task<bool> DeleteVolunteerAsync(Volunteer a, CancellationToken cancellationToken = default);
}
public class VolunteersRepo : IVolunteersRepo
{
    public async Task<List<Volunteer>> GetVolunteersAsync(CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.Volunteers.ToListAsync(cancellationToken);
    }
    public async Task<Volunteer> GetVolunteerAsync(int ID, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.Volunteers.Where(x => x.Id == ID).FirstOrDefaultAsync(cancellationToken) ?? new Volunteer();
    }
    public Volunteer GetVolunteer(int ID)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return db.Volunteers.Where(x => x.Id == ID).FirstOrDefault() ?? new Volunteer();
    }
    public async Task<int> UpdateVolunteerAsync(Volunteer a, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (a.Id == 0)
        {
            db.Volunteers.Add(a);
        }
        else if (a.Id != 0)
        {
            db.Volunteers.Update(a);
        }
        await db.SaveChangesAsync(cancellationToken);

        return a.Id;
    }
    public async Task<bool> DeleteVolunteerAsync(Volunteer a, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (a.Id != 0)
        {
            db.Volunteers.Remove(a);
            await db.SaveChangesAsync(cancellationToken);
            return true;
        }
        return false;
    }
}
