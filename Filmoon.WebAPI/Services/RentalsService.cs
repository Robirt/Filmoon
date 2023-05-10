using Filmoon.Entities;
using Filmoon.Responses;
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

    public async Task<ActionResponse> AddAsync(RentalEntity rental)
    {
        try
        {
            rental.StartDateTime = DateTime.Now;
            rental.EndDateTime = DateTime.Now.AddDays(7);

            await RentalsRepository.AddAsync(rental);

            return new ActionResponse(true, "Rental was added successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Rental was not added successful. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }

    public async Task<ActionResponse> UpdateAsync(RentalEntity rental)
    {
        try
        {
            await RentalsRepository.UpdateAsync(rental);

            return new ActionResponse(true, "Rental was updated successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Screenwriter was not updated successful. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }

    public async Task<ActionResponse> RemoveAsync(int id)
    {
        var rental = await RentalsRepository.GetByIdAsync(id);

        if (rental == null) return new ActionResponse(false, $"Rental with Id {id} was not found.");

        try
        {
            await RentalsRepository.RemoveAsync(rental);

            return new ActionResponse(true, "Rental was removed successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Rental was not removed successful. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }
}
