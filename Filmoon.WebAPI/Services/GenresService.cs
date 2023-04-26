using Filmoon.Entities;
using Filmoon.Responses;
using Filmoon.WebAPI.Repositories;

namespace Filmoon.WebAPI.Services;

public class GenresService
{
    public GenresService(GenresRepository genresRepository)
    {
        GenresRepository = genresRepository;
    }

    private GenresRepository GenresRepository { get; }

    public async Task<List<GenreEntity>> GetAsync()
    {
        return await GenresRepository.GetAsync();
    }

    public async Task<GenreEntity?> GetByIdAsync(int id)
    {
        return await GenresRepository.GetByIdAsync(id);
    }

    public async Task<GenreEntity?> GetByNameAsync(string name)
    {
        return (await GenresRepository.GetAsync(g => g.Name == name)).FirstOrDefault();
    }

    public async Task<ActionResponse> AddAsync(GenreEntity genre)
    {
        try
        {
            await GenresRepository.AddAsync(genre);

            return new ActionResponse(true, "Genre was added successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Genre was not added successful. Exception occurred: {exception.Message ?? exception.InnerException?.Message ?? "Undefined exception"}.");
        }
    }

    public async Task<ActionResponse> UpdateAsync(GenreEntity genre)
    {
        if (await GenresRepository.GetByIdAsync(genre.Id) is null) return new ActionResponse(false, $"Genre with Id {genre.Id} was not found.");

        try
        {
            await GenresRepository.UpdateAsync(genre);

            return new ActionResponse(true, "Genre was updated successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Genre was not updated successful. Exception occurred: {exception.Message ?? exception.InnerException?.Message ?? "Undefined exception"}.");
        }
    }

    public async Task<ActionResponse> RemoveAsync(int id)
    {
        var genre = await GenresRepository.GetByIdAsync(id);

        if (genre == null) return new ActionResponse(false, $"Genre with Id {id} was not found.");

        try
        {
            await GenresRepository.RemoveAsync(genre);

            return new ActionResponse(true, "Genre was removed successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(true, $"Genre was not removed successful. Exception occurred: {exception.Message ?? exception.InnerException?.Message ?? "Undefined exception"}.");
        }
    }
}
