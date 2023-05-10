using Filmoon.Entities;
using Filmoon.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Filmoon.Repositories;

public class MoviesRepository
{
    public MoviesRepository(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<MovieEntity>?> GetAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<MovieEntity>>("Movies");
    }

    public async Task<MovieEntity?> GetByIdAsync(int id)
    {
        return await HttpClient.GetFromJsonAsync<MovieEntity>($"Movies/{id}");
    }

    public async Task<ActionResponse?> AddAsync(MovieEntity movie)
    {
        return await (await HttpClient.PostAsJsonAsync("Movies", movie)).Content.ReadFromJsonAsync<ActionResponse>();
    }

    public async Task<ActionResponse?> UpdateAsync(MovieEntity movie)
    {
        return await (await HttpClient.PutAsJsonAsync("Movies", movie)).Content.ReadFromJsonAsync<ActionResponse>();
    }

    public async Task<ActionResponse?> RemoveAsync(int id)
    {
        return await (await HttpClient.DeleteAsync($"Movies/{id}")).Content.ReadFromJsonAsync<ActionResponse>();
    }
}

