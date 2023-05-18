using Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace Coursework.DAL;

public class DivisionsDAO
{
    private readonly CourseworkApplicationContext db;

    public DivisionsDAO(CourseworkApplicationContext courseworkApplicationContext)
    {
        db = courseworkApplicationContext;
    }
    public async Task<List<NationalDivision>> GetAllConferences()
    {
        return await db.Divisions
            .Include(d => d.Conferences)
            .ToListAsync()
            .ConfigureAwait(false);
    }
}