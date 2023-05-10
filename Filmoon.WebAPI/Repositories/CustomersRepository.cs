using Filmoon.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Filmoon.WebAPI.Repositories;

public class CustomersRepository
{
    public CustomersRepository(FilmoonContext filmoonContext)
    {
        FilmoonContext = filmoonContext;
    }

    private FilmoonContext FilmoonContext { get; }

    public async Task<List<CustomerEntity>> GetAsync()
    {
        return await FilmoonContext.Customers.ToListAsync();
    }

    public async Task<CustomerEntity?> GetByIdAsync(int id)
    {
        return await FilmoonContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<CustomerEntity?> GetByUserNameAsync(string userName)
    {
        return await FilmoonContext.Customers.FirstOrDefaultAsync(c => c.UserName == userName);
    }

    public async Task AddAsync(CustomerEntity customer)
    {
        try
        {
            await FilmoonContext.Customers.AddAsync(customer);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task UpdateAsync(CustomerEntity customer)
    {
        try
        {
            FilmoonContext.Customers.Update(customer);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task RemoveAsync(CustomerEntity customer)
    {
        try
        {
            FilmoonContext.Customers.Remove(customer);
            await FilmoonContext.SaveChangesAsync();
        }

        catch (DbUpdateException)
        {
            throw;
        }
    }
}
