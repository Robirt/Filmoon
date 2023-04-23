using Filmoon.Entities;
using Microsoft.EntityFrameworkCore;

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
        return await FilmoonContext.Users.OfType<CustomerEntity>().ToListAsync();
    }

    public async Task<CustomerEntity?> GetByIdAsync(int id)
    {
        return await FilmoonContext.Users.OfType<CustomerEntity>().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<CustomerEntity?> GetByUserNameAsync(string userName)
    {
        return await FilmoonContext.Users.OfType<CustomerEntity>().FirstOrDefaultAsync(c => c.UserName == userName);
    }

    public async Task AddAsync(CustomerEntity customer)
    {

    }

    public async Task UpdateAsync(CustomerEntity customer)
    {

    }

    public async Task RemoveAsync(CustomerEntity customer)
    {

    }
}
