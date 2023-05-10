using Filmoon.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Filmoon.WebAPI.Repositories;

public class DirectorsRepository
{
    public DirectorsRepository(FilmoonContext filmoonContext)
    {
        FilmoonContext = filmoonContext;
    }

    private FilmoonContext FilmoonContext { get; }

    public async Task<List<DirectorEntity>> GetAsync()
    {
        return await FilmoonContext.Directors.ToListAsync();
    }

    public async Task<List<DirectorEntity>> GetAsync(Expression<Func<DirectorEntity, bool>> expression)
    {
        return await FilmoonContext.Directors.Where(expression).ToListAsync();
    }

    public async Task<DirectorEntity?> GetByIdAsync(int id)
    {
        return await FilmoonContext.Directors.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task AddAsync(DirectorEntity director)
    {
        try
        {
            await FilmoonContext.Directors.AddAsync(director);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task UpdateAsync(DirectorEntity director)
    {
        try
        {
            FilmoonContext.Directors.Update(director);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task RemoveAsync(DirectorEntity director)
    {
        try
        {
            FilmoonContext.Directors.Remove(director);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }
}
