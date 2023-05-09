using Filmoon.Entities;
using Filmoon.Repositories;
using Filmoon.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmoon.Services;

public class ScreenwritersService
{
    public ScreenwritersService(ScreenwritersRepository screenwritersRepository)
    {
        ScreenwritersRepository = screenwritersRepository;
    }

    private ScreenwritersRepository ScreenwritersRepository { get; }

    public async Task<List<ScreenwriterEntity>?> GetAsync()
    {
        return await ScreenwritersRepository.GetAsync();
    }

    public async Task<ActionResponse?> AddAsync(ScreenwriterEntity screenwriter)
    {
        return await ScreenwritersRepository.AddAsync(screenwriter);
    }

    public async Task<ActionResponse?> UpdateAsync(ScreenwriterEntity screenwriter)
    {
        return await ScreenwritersRepository.UpdateAsync(screenwriter);
    }

    public async Task<ActionResponse?> RemoveAsync(ScreenwriterEntity screenwriter)
    {
        return await ScreenwritersRepository.RemoveAsync(screenwriter.Id);
    }
}
