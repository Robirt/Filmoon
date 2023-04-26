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

            return new ActionResponse(true, "Director was added successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Director was not added successful. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }

    public async Task<ActionResponse> UpdateAsync(DirectorEntity director)
    {
        try
        {
            await DirectorsRepository.UpdateAsync(director);

            return new ActionResponse(true, "Director was updated successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Director was not updated successful. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }

    public async Task<ActionResponse> RemoveAsync(int id)
    {
        var director = await DirectorsRepository.GetByIdAsync(id);

        if (director == null) return new ActionResponse(false, $"Director with Id {id} was not found.");

        try
        {
            await DirectorsRepository.RemoveAsync(director);

            return new ActionResponse(true, "Director was removed successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Director was not removed successful. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }
}
