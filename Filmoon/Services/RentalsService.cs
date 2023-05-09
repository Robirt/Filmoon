using Filmoon.Entities;
using Filmoon.Repositories;
using Filmoon.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmoon.Services;

public class RentalsService
{
    public RentalsService(RentalsRepository rentalsRepository)
    {
        RentalsRepository = rentalsRepository;
    }

    private RentalsRepository RentalsRepository { get; }

    public async Task<List<RentalEntity>?> GetAsync()
    {
        return await RentalsRepository.GetAsync();
    }

    public async Task<ActionResponse?> AddAsync(RentalEntity rental)
    {
        return await RentalsRepository.AddAsync(rental);
    }

    public async Task<ActionResponse?> UpdateAsync(RentalEntity rental)
    {
        return await RentalsRepository.UpdateAsync(rental);
    }

    public async Task<ActionResponse?> RemoveAsync(RentalEntity rental)
    {
        return await RentalsRepository.RemoveAsync(rental.Id);
    }
}
