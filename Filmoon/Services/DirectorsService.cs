using Filmoon.Entities;
using Filmoon.Repositories;
using Filmoon.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmoon.Services;

public class DirectorsService
{
    public DirectorsService(DirectorsRepository directorsRepository)
    {
        DirectorsRepository = directorsRepository;
    }

    private DirectorsRepository DirectorsRepository { get; }

    public async Task<List<DirectorEntity>?> GetAsync()
    {
        return await DirectorsRepository.GetAsync();
    }

    public async Task<ActionResponse?> AddAsync(DirectorEntity director)
    {
        return await DirectorsRepository.AddAsync(director);
    }

    public async Task<ActionResponse?> UpdateAsync(DirectorEntity director)
    {
        return await DirectorsRepository.UpdateAsync(director);
    }

    public async Task<ActionResponse?> DeleteAsync(DirectorEntity director)
    {
        return await DirectorsRepository.DeleteAsync(director.Id);
    }
}
