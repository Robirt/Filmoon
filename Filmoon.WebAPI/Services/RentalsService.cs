using Filmoon.Entities;
using Filmoon.WebAPI.Repositories;

namespace Filmoon.WebAPI.Services;

public class RentalsService
{
    public RentalsService(RentalsRepository rentalsRepository)
    {
        RentalsRepository = rentalsRepository;
    }

    private RentalsRepository RentalsRepository { get; }

    public async Task<List<RentalEntity>> GetByCustomerIdAsync(int customerId)
    {
        return await RentalsRepository.GetAsync(r => r.CustomerId == customerId);
    }

    public async Task<RentalEntity?> GetByIdAsync(int id)
    {
        return await RentalsRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(RentalEntity rental)
    {
        await RentalsRepository.AddAsync(rental);
    }

    public async Task UpdateAsync(RentalEntity rental)
    {
        if (await RentalsRepository.GetByIdAsync(rental.Id) is null) throw new ArgumentException($"Rental with Id {rental.Id} not found", nameof(rental.Id));

        await RentalsRepository.UpdateAsync(rental);
    }

    public async Task RemoveAsync(int id)
    {
        var rental = await RentalsRepository.GetByIdAsync(id);

        if (rental == null) throw new ArgumentException($"Rental with Id {id} not found", nameof(id));

        await RentalsRepository.RemoveAsync(rental);
    }
}
