using Moms250Blazor.Common;
using Microsoft.EntityFrameworkCore;

namespace Moms250Blazor.Data.Repository
{
    public interface IUsersRepo
    {
        Task<List<ApplicationUser>> GetAllUsersAsync(CancellationToken cancellationToken = default);
        Task<List<MyListItems>> GetMyListItemsAllUsersAsync(MyUserListItemsType listType, CancellationToken cancellationToken = default);
        Task<List<ApplicationUser>> GetAllUsersAsyncWithoutAdmin(CancellationToken cancellationToken = default);
        Task<List<ApplicationUser>> GetAllUsersWithProfileDataAsync(CancellationToken cancellationToken = default);
        Task<ApplicationUser> GetApplicationUserByIdAsync(string Id, CancellationToken cancellationToken = default);
        Task<ApplicationUser> GetApplicationUserByUsernameAsync(string username, CancellationToken cancellationToken = default);
        ApplicationUser GetApplicationUser(string Id);
        Task<List<ApplicationUser>> GetAllManagersDataAsync(CancellationToken cancellationToken = default);
        Task<List<ApplicationUser>> GetAllManagersWithProfileDataAsync(CancellationToken cancellationToken = default);
        Task<bool> UpdateApplicationUserAsync(ApplicationUser a, CancellationToken cancellationToken = default);
        Task<bool> UpdateNewlyCreatedApplicationUserAsync(string Id, ApplicationUser a, CancellationToken cancellationToken = default);
        Task<bool> UpdateUserProfileAsync(ApplicationUser ud, CancellationToken cancellationToken = default);
        Task<bool> DeleteApplicationUserAsync(ApplicationUser a, CancellationToken cancellationToken = default);
    }
    public class UsersRepo : IUsersRepo
    {
        public async Task<List<ApplicationUser>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            return await db.Users.ToListAsync(cancellationToken);
        }
        public async Task<List<MyListItems>> GetMyListItemsAllUsersAsync(MyUserListItemsType listType, CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            if (listType == MyUserListItemsType.FullNameAsSelector)
                return await db.Users.Select(x => new MyListItems() { I = x.ApplicationUserId, S = x.Id, Text = x.FullName ?? "" }).OrderBy(x => x.Text).ToListAsync(cancellationToken);
            else if (listType == MyUserListItemsType.FullNameAsSelectorManagersOnly)
                return await db.Users.Where(x => x.NationalChair == true || x.SeniorCoordinator == true || x.Coordinator == true).Select(x => new MyListItems() { I = x.ApplicationUserId, S = x.Id, Text = x.FullName ?? "" }).OrderBy(x => x.Text).ToListAsync(cancellationToken);
            else if (listType == MyUserListItemsType.FullNameAsSelectorLeadVolunteersOnly)
                return await db.Users.Select(x => new MyListItems() { I = x.ApplicationUserId, S = x.Id, Text = x.FullName ?? "" }).OrderBy(x => x.Text).ToListAsync(cancellationToken);
            else if (listType == MyUserListItemsType.FullNameAsSelectorWithEmailAttribute)
                return await db.Users.Select(x => new MyListItems() { I = x.ApplicationUserId, S = x.Id, Text = x.FullName ?? "", Attrb1 = x.Email }).OrderBy(x => x.Text).ToListAsync(cancellationToken);
            else if (listType == MyUserListItemsType.FullNameAsSelectorWithEmailAndStateAttributes)
                return await db.Users.Select(x => new MyListItems() { I = x.ApplicationUserId, S = x.Id, Text = x.FullName ?? "", Attrb1 = x.Email, Attrb2 = x.State }).OrderBy(x => x.Text).ToListAsync(cancellationToken);
            else if (listType == MyUserListItemsType.UserNameAsSelector)
                return await db.Users.Select(x => new MyListItems() { I = x.ApplicationUserId, S = x.Id, Text = x.UserName ?? "" }).OrderBy(x => x.Text).ToListAsync(cancellationToken);
            else
                return [];
        }
        public async Task<List<ApplicationUser>> GetAllUsersAsyncWithoutAdmin(CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            return await db.Users.Where(x => x.Email != "erikcheatham@gmail.com").ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationUser>> GetAllUsersWithProfileDataAsync(CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            return await db.Users.ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationUser>> GetAllUsersWithoutAdminWithProfileDataAsync(CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            return await db.Users.Where(x => x.Email != "erikcheatham@gmail.com").ToListAsync(cancellationToken);
        }
        public async Task<ApplicationUser> GetApplicationUserByIdAsync(string Id, CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            return await db.Users.Where(x => x.Id == Id).FirstOrDefaultAsync(cancellationToken) ?? new ApplicationUser();
        }
        public async Task<ApplicationUser> GetApplicationUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            return await db.Users.Where(x => x.UserName == username).FirstOrDefaultAsync(cancellationToken) ?? new ApplicationUser();
        }
        public ApplicationUser GetApplicationUser(string Id)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            return db.Users.Where(x => x.Id == Id).FirstOrDefault() ?? new ApplicationUser();
        }
        public async Task<List<ApplicationUser>> GetAllVolunteersDataAsync(CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            return await db.Users.Where(x => x.Email != "erikcheatham@gmail.com").ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationUser>> GetAllManagersDataAsync(CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            return await db.Users.Where(x => x.NationalChair == true || x.SeniorCoordinator == true || x.Coordinator == true).ToListAsync(cancellationToken);
        }
        public async Task<List<ApplicationUser>> GetAllManagersWithProfileDataAsync(CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            return await db.Users.Where(x => x.NationalChair == true || x.SeniorCoordinator == true || x.Coordinator == true).ToListAsync(cancellationToken);
        }
        public async Task<bool> UpdateApplicationUserAsync(ApplicationUser a, CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            if (a.Id is null)
            {
                db.Users.Add(a);
            }
            else if (a.Id is not null)
            {
                db.Users.Update(a);
            }
            await db.SaveChangesAsync(cancellationToken);

            return true;
        }
        public async Task<bool> UpdateNewlyCreatedApplicationUserAsync(string Id, ApplicationUser a, CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            var u = db.Users.Where(x => x.Id == Id).FirstOrDefault();
            if (u?.Id is not null)
            {
                u.EmailConfirmed = true;
                u.PhoneNumberConfirmed = true;
                u.PhoneNumber = a.PhoneNumber;

                db.Users.Update(u);
                await db.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateUserProfileAsync(ApplicationUser ud, CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            if (ud.Id is null)
            {
                db.Users.Add(ud);
                await db.SaveChangesAsync(cancellationToken);
                return true;
            }
            else if (ud.Id is not null)
            {
                db.Entry(ud).Property(x => x.ApplicationUserId).IsModified = false;
                db.Users.Update(ud);
                await db.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteApplicationUserAsync(ApplicationUser a, CancellationToken cancellationToken = default)
        {
            using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            if (a.Id is not null)
            {
                db.Users.Remove(a);
                await db.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
