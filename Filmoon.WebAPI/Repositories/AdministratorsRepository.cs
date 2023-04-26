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
        try
        {
            await FilmoonContext.Users.AddAsync(administrator);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task UpdateAsync(AdministratorEntity administrator)
    {
        try
        {
            FilmoonContext.Users.Update(administrator);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task RemoveAsync(AdministratorEntity administrator)
    {
        try
        {
            FilmoonContext.Users.Remove(administrator);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }
}
