using Filmoon.Entities;
using Filmoon.Repositories;
using Filmoon.Responses;
using System.Threading.Tasks;

namespace Filmoon.Services;

public class RentalsService
{
    public RentalsService(RentalsRepository rentalsRepository)
    {
        RentalsRepository = rentalsRepository;
    }

    private RentalsRepository RentalsRepository { get; }

    public async Task<ActionResponse?> AddAsync(RentalEntity rental)
    {
        return await RentalsRepository.AddAsync(rental);
    }

    public async Task<ActionResponse?> UpdateAsync(RentalEntity rental)
    {
        return await RentalsRepository.UpdateAsync(rental);
    }
}
