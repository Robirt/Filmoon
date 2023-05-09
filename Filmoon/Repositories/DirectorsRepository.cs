using Filmoon.Entities;
using Filmoon.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Filmoon.Repositories;

public class DirectorsRepository
{
    public DirectorsRepository(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<DirectorEntity>?> GetAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<DirectorEntity>>("Directors");
    }

    public async Task<DirectorEntity?> GetByIdAsync(int id)
    {
        return await HttpClient.GetFromJsonAsync<DirectorEntity>($"Directors/{id}");
    }

    public async Task<ActionResponse?> AddAsync(DirectorEntity director)
    {
        return await (await HttpClient.PostAsJsonAsync("Directors", director)).Content.ReadFromJsonAsync<ActionResponse>();
    }

    public async Task<ActionResponse?> UpdateAsync(DirectorEntity director)
    {
        return await (await HttpClient.PutAsJsonAsync("Directors", director)).Content.ReadFromJsonAsync<ActionResponse>();
    }

    public async Task<ActionResponse?> RemoveAsync(int id)
    {
        return await (await HttpClient.DeleteAsync($"Directors/{id}")).Content.ReadFromJsonAsync<ActionResponse>();
    }
}
