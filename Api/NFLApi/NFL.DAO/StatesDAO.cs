using Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace NFL.DAO;

public class StatesDAO
{
    public async Task<List<State>> GetStatesAsync()
    {
        await using var db = new NFLApplicationContext();
        return await db.States!
            .ToListAsync()
            .ConfigureAwait(false);
    }


    public async Task<State?> GetStateById(string stateCode)
    {
        await using var db = new NFLApplicationContext();
        return await db.States!
            .FindAsync(stateCode)
            .ConfigureAwait(false);
    }
}