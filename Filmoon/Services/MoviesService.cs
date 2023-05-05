using Filmoon.Entities;
using Filmoon.Repositories;
using Filmoon.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmoon.Services;

public class MoviesService
{
    public MoviesService(MoviesRepository moviesRepository)
    {
        MoviesRepository = moviesRepository;
    }

    private MoviesRepository MoviesRepository { get; }

    public async Task<List<MovieEntity>?> GetAsync()
    {
        return await MoviesRepository.GetAsync();
    }

    public async Task<ActionResponse?> AddAsync(MovieEntity movie)
    {
        return await MoviesRepository.AddAsync(movie);
    }
}
