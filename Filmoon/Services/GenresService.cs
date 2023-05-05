using Filmoon.Entities;
using Filmoon.Repositories;
using Filmoon.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmoon.Services;

public class GenresService
{
    public GenresService(GenresRepository genresRepository)
    {
        GenresRepository = genresRepository;
    }

    private GenresRepository GenresRepository { get; }

    public async Task<List<GenreEntity>?> GetAsync()
    {
        return await GenresRepository.GetAsync();
    }

    public async Task<ActionResponse?> AddAsync(GenreEntity genre)
    {
        return await GenresRepository.AddAsync(genre);
    }

    public async Task<ActionResponse?> UpdateAsync(GenreEntity genre)
    {
        return await GenresRepository.UpdateAsync(genre);
    }

    public async Task<ActionResponse?> DeleteAsync(GenreEntity genre)
    {
        return await GenresRepository.DeleteAsync(genre.Id);
    }
}
