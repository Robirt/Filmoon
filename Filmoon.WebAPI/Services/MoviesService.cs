using Filmoon.Entities;
using Filmoon.Responses;
using Filmoon.WebAPI.Repositories;

namespace Filmoon.WebAPI.Services;

public class MoviesService
{
    public MoviesService(MoviesRepository moviesRepository)
    {
        MoviesRepository = moviesRepository;
    }

    private MoviesRepository MoviesRepository { get; }

    public async Task<List<MovieEntity>> GetAsync()
    {
        return await MoviesRepository.GetAsync();
    }

    public async Task<MovieEntity?> GetByIdAsync(int id)
    {
        return await MoviesRepository.GetByIdAsync(id);
    }

    public async Task<MovieEntity?> GetByTitleAsync(string title)
    {
        return (await MoviesRepository.GetAsync(m => m.Title == title)).FirstOrDefault();
    }

    public async Task<ActionResponse> AddAsync(MovieEntity movie)
    {
        try
        {
            await MoviesRepository.AddAsync(movie);

            return new ActionResponse(true, "Movie was added successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Movie was not added successful. Exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined exception"}.");
        }
    }

    public async Task<ActionResponse> UpdateAsync(MovieEntity movie)
    {
        if (await MoviesRepository.GetByIdAsync(movie.Id) is null) return new ActionResponse(false, $"Movie with Id {movie.Id} was not found.");

        try
        {
            await MoviesRepository.UpdateAsync(movie);

            return new ActionResponse(true, "Movie was updated successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Movie was not updated successful. Exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined exception"}.");
        }
    }

    public async Task<ActionResponse> RemoveAsync(int id)
    {
        var movie = await MoviesRepository.GetByIdAsync(id);

        if (movie == null) return new ActionResponse(false, $"Movie with Id {id} was not found.");

        try
        {
            await MoviesRepository.RemoveAsync(movie);

            return new ActionResponse(true, "Movie was removed successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(true, $"Movie was not removed successful. Exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined exception"}.");
        }
    }
}
