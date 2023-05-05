using Entities.Tables;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace NFL.DAO;

public class DivisionsDAO
{
    public async Task<List<NationalDivision>> GetAllConferences()
    {
        await using var db = new NFLApplicationContext();
        return await db.Divisions
            .Include(d => d.Conferences)
            .ToListAsync()
            .ConfigureAwait(false);
    }
}