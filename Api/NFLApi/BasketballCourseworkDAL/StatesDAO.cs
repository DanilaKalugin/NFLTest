using Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace Coursework.DAL;

public class StatesDAO
{
    private readonly CourseworkApplicationContext db;

    public StatesDAO(CourseworkApplicationContext courseworkApplicationContext) => db = courseworkApplicationContext;

    public async Task<List<State>> GetStatesAsync()
    {
        return await db.States!
            .ToListAsync()
            .ConfigureAwait(false);
    }


    public async Task<State?> GetStateById(string stateCode)
    {
        return await db.States!
            .FindAsync(stateCode)
            .ConfigureAwait(false);
    }
}