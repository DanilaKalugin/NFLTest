using Coursework.DAL;
using Entities.DTOs;
using Entities.Tables;

namespace Coursework.BLL;

public class UserBL
{
    private readonly UserDAO _userDao;

    public UserBL(UserDAO userDao)
    {
        _userDao = userDao;
    }

    public async Task<User?> GetUserAsync(string email, string password)
    {
        return await _userDao.GetUserAsync(email, password).ConfigureAwait(false);
    }

    public async Task RegisterUser(UserRegisterDto user)
    {
        await _userDao.RegisterUser(user).ConfigureAwait(false);
    }

    public async Task<bool> CheckUserWithThiEmailIsExistsAsync(string email)
    {
        return await _userDao.CheckUserWithThiEmailIsExistsAsync(email).ConfigureAwait(false);
    }
}