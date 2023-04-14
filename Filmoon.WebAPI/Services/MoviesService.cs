using Filmoon.Entities;
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
        return (await MoviesRepository.GetAsync(x => x.Title == title)).FirstOrDefault();
    }

    public async Task AddAsync(MovieEntity movie)
    {
        await MoviesRepository.AddAsync(movie);
    }

    public async Task UpdateAsync(MovieEntity movie)
    {
        if (await MoviesRepository.GetByIdAsync(movie.Id) is null) throw new ArgumentException($"Movie with Id {movie.Id} not found", nameof(movie.Id));

        await MoviesRepository.UpdateAsync(movie);
    }

    public async Task RemoveAsync(int id)
    {
        var movie = await MoviesRepository.GetByIdAsync(id);

        if (movie == null) throw new ArgumentException($"Movie with Id {id} not found", nameof(id));

        await MoviesRepository.RemoveAsync(movie);
    }
}
