using Filmoon.Entities;
using Filmoon.Responses;
using Filmoon.WebAPI.Repositories;

namespace Filmoon.WebAPI.Services;

public class DirectorsService
{
    public DirectorsService(DirectorsRepository directorsRepository)
    {
        DirectorsRepository = directorsRepository;
    }

    private DirectorsRepository DirectorsRepository { get; }

    public async Task<List<DirectorEntity>> GetAsync()
    {
        return await DirectorsRepository.GetAsync();
    }

    public async Task<DirectorEntity?> GetByIdAsync(int id)
    {
        return await DirectorsRepository.GetByIdAsync(id);
    }

    public async Task<ActionResponse> AddAsync(DirectorEntity director)
    {
        try
        {
            await DirectorsRepository.AddAsync(director);

            return new ActionResponse(true, "Director was added successfully.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Director was not added. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }

    public async Task<ActionResponse> UpdateAsync(DirectorEntity director)
    {
        try
        {
            await DirectorsRepository.UpdateAsync(director);

            return new ActionResponse(true, "Director was updated successfully.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Director was not updated. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }

    public async Task<ActionResponse> RemoveAsync(DirectorEntity director)
    {
        try
        {
            await DirectorsRepository.RemoveAsync(director);

            return new ActionResponse(true, "Director was removed successfully.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Director was not removed. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }
}
