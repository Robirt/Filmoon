using Filmoon.Entities;
using Filmoon.Responses;
using Filmoon.WebAPI.Repositories;

namespace Filmoon.WebAPI.Services;

public class ScreenwritersService
{
    public ScreenwritersService(ScreenwritersRepository screenwritersRepository)
    {
        ScreenwritersRepository = screenwritersRepository;
    }

    private ScreenwritersRepository ScreenwritersRepository { get; }

    public async Task<List<ScreenwriterEntity>> GetAsync()
    {
        return await ScreenwritersRepository.GetAsync();
    }

    public async Task<ScreenwriterEntity?> GetByIdAsync(int id)
    {
        return await ScreenwritersRepository.GetByIdAsync(id);
    }

    public async Task<ActionResponse> AddAsync(ScreenwriterEntity screenwriter)
    {
        try
        {
            await ScreenwritersRepository.AddAsync(screenwriter);

            return new ActionResponse(true, "Screenwriter was added successfully.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Screenwriter was not added. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }

    public async Task<ActionResponse> UpdateAsync(ScreenwriterEntity screenwriter)
    {
        try
        {
            await ScreenwritersRepository.UpdateAsync(screenwriter);

            return new ActionResponse(true, "Screenwriter was updated successfully.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Screenwriter was not updated. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }

    public async Task<ActionResponse> RemoveAsync(ScreenwriterEntity screenwriter)
    {
        try
        {
            await ScreenwritersRepository.RemoveAsync(screenwriter);

            return new ActionResponse(true, "Screenwriter was removed successfully.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Screenwriter was not removed. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }
}
