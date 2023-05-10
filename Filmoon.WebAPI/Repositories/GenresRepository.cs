using Filmoon.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Filmoon.WebAPI.Repositories;

public class GenresRepository
{
    public GenresRepository(FilmoonContext filmoonContext)
    {
        FilmoonContext = filmoonContext;
    }

    private FilmoonContext FilmoonContext { get; }

    public async Task<List<GenreEntity>> GetAsync()
    {
        return await FilmoonContext.Genres.ToListAsync();
    }

    public async Task<List<GenreEntity>> GetAsync(Expression<Func<GenreEntity, bool>> expression)
    {
        return await FilmoonContext.Genres.Where(expression).ToListAsync();
    }

    public async Task<GenreEntity?> GetByIdAsync(int id)
    {
        return await FilmoonContext.Genres.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task AddAsync(GenreEntity genre)
    {
        try
        {
            await FilmoonContext.Genres.AddAsync(genre);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task UpdateAsync(GenreEntity genre)
    {
        try
        {
            FilmoonContext.Genres.Update(genre);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task RemoveAsync(GenreEntity genre)
    {
        try
        {
            FilmoonContext.Genres.Remove(genre);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }
}
