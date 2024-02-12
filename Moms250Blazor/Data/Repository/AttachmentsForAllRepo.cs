using Moms250Blazor.Common;
using Microsoft.EntityFrameworkCore;

namespace Moms250Blazor.Data.Repository;
public interface IAttachmentsForAllRepo
{
    Task<List<AttachmentsForAll>> GetAssignmentAttachmentsForAllAsync(CancellationToken cancellationToken = default);
    Task<AttachmentsForAll> GetAttachmentAsync(int Id, CancellationToken cancellationToken = default);
    Task<List<AttachmentsForAll>> GetAttachmentsForAllByType(string AttachmentType, CancellationToken cancellationToken = default);
    Task<bool> UpdateAttachmentForAllAsync(List<AttachmentsForAll> aList, CancellationToken cancellationToken = default);
    Task<bool> DeleteAssignmentForAllAsync(AttachmentsForAll a, CancellationToken cancellationToken = default);
}
public class AttachmentsForAllRepo : IAttachmentsForAllRepo
{
    public async Task<List<AttachmentsForAll>> GetAssignmentAttachmentsForAllAsync(CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.AttachmentsForAlls.ToListAsync(cancellationToken);
    }
    public async Task<AttachmentsForAll> GetAttachmentAsync(int Id, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.AttachmentsForAlls.Where(x => x.Id == Id).FirstOrDefaultAsync(cancellationToken) ?? new AttachmentsForAll();
    }
    public async Task<List<AttachmentsForAll>> GetAttachmentsForAllByType(string AttachmentType, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.AttachmentsForAlls.Where(x => x.Type == AttachmentType).ToListAsync(cancellationToken);
    }
    public async Task<bool> UpdateAttachmentForAllAsync(List<AttachmentsForAll> aList, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        foreach (var a in aList)
        {
            if (a.Id == 0)
            {
                db.AttachmentsForAlls.Add(a);
            }
            else if (a.Id != 0)
            {
                db.AttachmentsForAlls.Update(a);
            }
        }
        await db.SaveChangesAsync(cancellationToken);

        return true;
    }
    public async Task<bool> DeleteAssignmentForAllAsync(AttachmentsForAll a, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (db.AttachmentsForAlls.Any(x => x.Id == a.Id))
        {
            db.AttachmentsForAlls.Remove(a);
            await db.SaveChangesAsync(cancellationToken);
            return true;
        }
        return false;
    }
}
