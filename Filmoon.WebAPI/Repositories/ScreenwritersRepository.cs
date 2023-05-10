using Filmoon.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Filmoon.WebAPI.Repositories;

public class ScreenwritersRepository
{
    public ScreenwritersRepository(FilmoonContext filmoonContext)
    {
        FilmoonContext = filmoonContext;
    }

    private FilmoonContext FilmoonContext { get; }

    public async Task<List<ScreenwriterEntity>> GetAsync()
    {
        return await FilmoonContext.Screenwriters.ToListAsync();
    }

    public async Task<List<ScreenwriterEntity>> GetAsync(Expression<Func<ScreenwriterEntity, bool>> expression)
    {
        return await FilmoonContext.Screenwriters.Where(expression).ToListAsync();
    }

    public async Task<ScreenwriterEntity?> GetByIdAsync(int id)
    {
        return await FilmoonContext.Screenwriters.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(ScreenwriterEntity screenwriter)
    {
        try
        {
            await FilmoonContext.Screenwriters.AddAsync(screenwriter);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task UpdateAsync(ScreenwriterEntity screenwriter)
    {
        try
        {
            FilmoonContext.Screenwriters.Update(screenwriter);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task RemoveAsync(ScreenwriterEntity screenwriter)
    {
        try
        {
            FilmoonContext.Screenwriters.Remove(screenwriter);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }
}
