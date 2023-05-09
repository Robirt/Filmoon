using Filmoon.Entities;
using Filmoon.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Filmoon.Repositories;

public class ScreenwritersRepository
{
    public ScreenwritersRepository(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<ScreenwriterEntity>?> GetAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<ScreenwriterEntity>>("Screenwriters");
    }

    public async Task<ScreenwriterEntity?> GetByIdAsync(int id)
    {
        return await HttpClient.GetFromJsonAsync<ScreenwriterEntity>($"Screenwriters/{id}");
    }

    public async Task<ActionResponse?> AddAsync(ScreenwriterEntity screenwriter)
    {
        return await (await HttpClient.PostAsJsonAsync("Screenwriters", screenwriter)).Content.ReadFromJsonAsync<ActionResponse>();
    }

    public async Task<ActionResponse?> UpdateAsync(ScreenwriterEntity screenwriter)
    {
        return await (await HttpClient.PutAsJsonAsync("Screenwriters", screenwriter)).Content.ReadFromJsonAsync<ActionResponse>();
    }

    public async Task<ActionResponse?> RemoveAsync(int id)
    {
        return await (await HttpClient.DeleteAsync($"Screenwriters/{id}")).Content.ReadFromJsonAsync<ActionResponse>();
    }
}
