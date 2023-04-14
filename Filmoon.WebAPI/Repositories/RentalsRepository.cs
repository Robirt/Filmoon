using Filmoon.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace Filmoon.WebAPI.Repositories;

public class RentalsRepository
{
    public RentalsRepository(FilmoonContext filmoonContext)
    {
        FilmoonContext = filmoonContext;
    }

    private FilmoonContext FilmoonContext { get; }

    public async Task<List<RentalEntity>> GetAsync()
    {
        return await FilmoonContext.Rentals.ToListAsync();
    }

    public async Task<List<RentalEntity>> GetAsync(Expression<Func<RentalEntity, bool>> expression)
    {
        return await FilmoonContext.Rentals.Where(expression).ToListAsync();
    }

    public async Task<RentalEntity?> GetByIdAsync(int id)
    {
        return await FilmoonContext.Rentals.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task AddAsync(RentalEntity rental)
    {
        try
        {
            await FilmoonContext.Rentals.AddAsync(rental);
            await FilmoonContext.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task UpdateAsync(RentalEntity rental)
    {
        try
        {
            FilmoonContext.Rentals.Update(rental);
            await FilmoonContext.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task RemoveAsync(RentalEntity rental)
    {
        try
        {
            FilmoonContext.Rentals.Remove(rental);
            await FilmoonContext.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw;
        }
    }
}
