using Filmoon.Entities;
using Microsoft.EntityFrameworkCore;

namespace Filmoon.WebAPI.Repositories;

public class AdministratorsRepository
{
    public AdministratorsRepository(FilmoonContext filmoonContext)
    {
        FilmoonContext = filmoonContext;
    }

    private FilmoonContext FilmoonContext { get; }

    public async Task<List<AdministratorEntity>> GetAsync()
    {
        return await FilmoonContext.Users.OfType<AdministratorEntity>().ToListAsync();
    }

    public async Task<AdministratorEntity?> GetByIdAsync(int id)
    {
        return await FilmoonContext.Users.OfType<AdministratorEntity>().FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<AdministratorEntity?> GetByUserNameAsync(string userName)
    {
        return await FilmoonContext.Users.OfType<AdministratorEntity>().FirstOrDefaultAsync(a => a.UserName == userName);
    }

    public async Task AddAsync(AdministratorEntity administrator)
    {

    }

    public async Task UpdateAsync(AdministratorEntity administrator)
    {

    }

    public async Task RemoveAsync(AdministratorEntity administrator)
    {

    }
}
