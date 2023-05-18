using Entities.DTOs;
using Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace Coursework.DAL;

public class UserDAO
{
    private readonly CourseworkApplicationContext db;

    public UserDAO(CourseworkApplicationContext courseworkApplicationContext)
    {
        db = courseworkApplicationContext;
    }

    public async Task<User?> GetUserAsync(string email, string password)
    {
        return await db.Users
            .Include(u => u.FavoriteTeam)
            .ThenInclude(t => t.Colors)
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password).ConfigureAwait(false);
    }

    public async Task RegisterUser(UserRegisterDto user)
    {
        var userDb = new User
        {
            FavoriteTeamAbbreviation = user.FavoriteTeam,
            Email = user.Email,
            Password = user.Password
        };

        await db.Users.AddAsync(userDb);
        await db.SaveChangesAsync();
    }

    public async Task<bool> CheckUserWithThiEmailIsExistsAsync(string email)
    {
        return await db.Users.AnyAsync( u => u.Email == email);
    }
}