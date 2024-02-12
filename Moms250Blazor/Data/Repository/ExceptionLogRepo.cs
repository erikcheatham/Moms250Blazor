using Moms250Blazor.Common;
using Microsoft.EntityFrameworkCore;

namespace Moms250Blazor.Data.Repository;

public interface IExceptionLogRepo
{
    Task<List<ExceptionLog>> GetExceptionLogsAsync(CancellationToken cancellationToken = default);
    Task<ExceptionLog> GetExceptionLogAsync(int Id, CancellationToken cancellationToken = default);
    ExceptionLog GetExceptionLog(int Id);
    Task<List<MyListItems>> GetMyListItemsExceptionLogsAsync(CancellationToken cancellationToken = default);
    Task<int> AddExceptionLogAsync(ExceptionLog s, string userfullname, CancellationToken cancellationToken = default);
    Task<int> UpdateExceptionLogAsync(ExceptionLog s, string userfullname, CancellationToken cancellationToken = default);
    Task<bool> DeleteExceptionLogAsync(ExceptionLog s, CancellationToken cancellationToken = default);
}
public class ExceptionLogRepo : IExceptionLogRepo
{
    public async Task<List<ExceptionLog>> GetExceptionLogsAsync(CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.ExceptionLogs.ToListAsync(cancellationToken);
    }
    public async Task<List<MyListItems>> GetMyListItemsExceptionLogsAsync(CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.ExceptionLogs.Select(x => new MyListItems() { I = x.Id, Text = x.Message ?? "", Attrb1 = x.StackTrace ?? "", Attrb2 = x.Object ?? "" }).ToListAsync(cancellationToken);
    }
    public async Task<ExceptionLog> GetExceptionLogAsync(int Id, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.ExceptionLogs.Where(x => x.Id == Id).FirstOrDefaultAsync(cancellationToken) ?? new ExceptionLog();
    }
    public ExceptionLog GetExceptionLog(int Id)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return db.ExceptionLogs.Where(x => x.Id == Id).FirstOrDefault() ?? new ExceptionLog();
    }
    public async Task<int> AddExceptionLogAsync(ExceptionLog c, string userfullname, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (!db.ExceptionLogs.Any(x => x.Id == c.Id))
        {
            c.CreatedBy = userfullname;
            c.Created = DateTime.Now;
            db.ExceptionLogs.Add(c);
        }
        await db.SaveChangesAsync(cancellationToken);

        return c.Id;
    }
    public async Task<int> UpdateExceptionLogAsync(ExceptionLog c, string userfullname, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (db.ExceptionLogs.Any(x => x.Id == c.Id))
        {
            c.ModifiedBy = userfullname;
            c.Modified = DateTime.Now;
            db.ExceptionLogs.Update(c);
        }
        await db.SaveChangesAsync(cancellationToken);

        return c.Id;
    }
    public async Task<bool> DeleteExceptionLogAsync(ExceptionLog s, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (db.ExceptionLogs.Any(s => s.Id == s.Id))
        {
            db.ExceptionLogs.Remove(s);
            await db.SaveChangesAsync(cancellationToken);
            return true;
        }
        return false;
    }
}
