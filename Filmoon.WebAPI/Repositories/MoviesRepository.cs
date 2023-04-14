using Filmoon.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Filmoon.WebAPI.Repositories;

public class MoviesRepository
{
    public MoviesRepository(FilmoonContext filmoonContext)
    {
        FilmoonContext = filmoonContext;
    }

    private FilmoonContext FilmoonContext { get; }

    public async Task<List<MovieEntity>> GetAsync()
    {
        return await FilmoonContext.Movies.ToListAsync();
    }

    public async Task<List<MovieEntity>> GetAsync(Expression<Func<MovieEntity, bool>> expression)
    {
        return await FilmoonContext.Movies.Where(expression).ToListAsync();
    }

    public async Task<MovieEntity?> GetByIdAsync(int id)
    {
        return await FilmoonContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(MovieEntity movie)
    {
        try
        {
            await FilmoonContext.Movies.AddAsync(movie);
            await FilmoonContext.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task UpdateAsync(MovieEntity movie)
    {
        try
        {
            FilmoonContext.Movies.Update(movie);
            await FilmoonContext.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task RemoveAsync(MovieEntity movie)
    {
        try
        {
            FilmoonContext.Movies.Remove(movie);
            await FilmoonContext.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw;
        }
    }
}
