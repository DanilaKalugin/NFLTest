using Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace Coursework.DAL;

public class StadiumsDAO
{
    private readonly CourseworkApplicationContext db;
    
    public StadiumsDAO(CourseworkApplicationContext courseworkApplicationContext)
    {
        db = courseworkApplicationContext;
    }

    public async Task<Stadium?> GetStadiumById(short stadiumId)
    {
        return await db.Stadiums
            .Include(s => s.StadiumLocation)
            .FirstOrDefaultAsync(s => s.StadiumId == stadiumId);
    }
}