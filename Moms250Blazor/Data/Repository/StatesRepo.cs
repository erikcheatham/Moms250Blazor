using Moms250Blazor.Common;
using Microsoft.EntityFrameworkCore;

namespace Moms250Blazor.Data.Repository;

public interface IStatesRepo
{
    Task<List<State>> GetStatesAsync(CancellationToken cancellationToken = default);
    Task<State> GetStateAsync(string stateAb, CancellationToken cancellationToken = default);
    State GetState(string stateAb);
    Task<List<MyListItems>> GetMyListItemsStatesAsync(CancellationToken cancellationToken = default);
    Task<string> UpdateStateAsync(State s, CancellationToken cancellationToken = default);
    Task<bool> DeleteAssignmentAsync(State s, CancellationToken cancellationToken = default);
}
public class StatesRepo : IStatesRepo
{
    public async Task<List<State>> GetStatesAsync(CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.States.ToListAsync(cancellationToken);
    }
    public async Task<List<MyListItems>> GetMyListItemsStatesAsync(CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.States.Select(x => new MyListItems() { S = x.StateAb, Text = $"{x.StateAb} - {x.Name}" }).ToListAsync(cancellationToken);
    }
    public async Task<State> GetStateAsync(string stateAb, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return await db.States.Where(x => x.StateAb == stateAb).FirstOrDefaultAsync(cancellationToken) ?? new State();
    }
    public State GetState(string stateAb)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        return db.States.Where(x => x.StateAb == stateAb).FirstOrDefault() ?? new State();
    }
    public async Task<string> UpdateStateAsync(State s, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (!db.States.Any(s => s.StateAb == s.StateAb))
        {
            db.States.Add(s);
        }
        else if (db.States.Any(s => s.StateAb == s.StateAb))
        {
            db.States.Update(s);
        }
        await db.SaveChangesAsync(cancellationToken);

        return s.StateAb;
    }
    public async Task<bool> DeleteAssignmentAsync(State s, CancellationToken cancellationToken = default)
    {
        using var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        if (db.States.Any(s => s.StateAb == s.StateAb))
        {
            db.States.Remove(s);
            await db.SaveChangesAsync(cancellationToken);
            return true;
        }
        return false;
    }
}
