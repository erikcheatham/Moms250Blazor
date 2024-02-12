using Moms250Blazor.Common;
using Microsoft.EntityFrameworkCore;

namespace Moms250Blazor.Data.Repository;
public interface IAttachmentsRepo
{
    Task<List<Attachment>> GetAssignmentAttachmentsAsync(int Id, CancellationToken cancellationToken = default);
    Task<Attachment> GetAttachmentAsync(int Id, CancellationToken cancellationToken = default);
    Task<List<Attachment>> GetAttachmentsByType(string AttachmentType, CancellationToken cancellationToken = default);
    Task<int> UpdateAttachmentAsync(Attachment a, CancellationToken cancellationToken = default);
    Task<bool> DeleteAssignmentAsync(Attachment a, CancellationToken cancellationToken = default);
}
public class AttachmentsRepo : IAttachmentsRepo
{
    public async Task<List<Attachment>> GetAssignmentAttachmentsAsync(int Id, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.Attachments.Where(x => x.AssignmentId == Id).ToListAsync(cancellationToken);
    }
    public async Task<Attachment> GetAttachmentAsync(int Id, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.Attachments.Where(x => x.Id == Id).FirstOrDefaultAsync(cancellationToken) ?? new Attachment();
    }
    public async Task<List<Attachment>> GetAttachmentsByType(string AttachmentType, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.Attachments.Where(x => x.Type == AttachmentType).ToListAsync(cancellationToken);
    }
    public async Task<int> UpdateAttachmentAsync(Attachment a, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (a.Id == 0)
        {
            db.Attachments.Add(a);
        }
        else if (a.Id != 0)
        {
            db.Attachments.Update(a);
        }
        await db.SaveChangesAsync(cancellationToken);

        return a.Id;
    }
    public async Task<bool> DeleteAssignmentAsync(Attachment a, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (db.Attachments.Any(x => x.Id == a.Id && x.AssignmentId == a.AssignmentId))
        {
            db.Attachments.Remove(a);
            await db.SaveChangesAsync(cancellationToken);
            return true;
        }
        return false;
    }
}
