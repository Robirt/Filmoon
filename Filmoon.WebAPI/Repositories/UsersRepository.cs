using Filmoon.Entities;
using Microsoft.EntityFrameworkCore;

namespace Filmoon.WebAPI.Repositories;

public class UsersRepository
{
    public UsersRepository(FilmoonContext filmoonContext)
    {
        FilmoonContext = filmoonContext;
    }

    private FilmoonContext FilmoonContext { get; }

    public async Task<UserEntity?> GetByUserNameAsync(string userName)
    {
        return await FilmoonContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
    }
}
