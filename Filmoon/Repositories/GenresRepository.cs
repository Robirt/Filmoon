using Filmoon.Entities;
using Filmoon.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Filmoon.Repositories;

public class GenresRepository
{
    public GenresRepository(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<GenreEntity>?> GetAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<GenreEntity>>("/Genres");
    }

    public async Task<GenreEntity?> GetByIdAsync(int id)
    {
        return await HttpClient.GetFromJsonAsync<GenreEntity>($"/Genres/{id}");
    }

    public async Task<ActionResponse?> AddAsync(GenreEntity genre)
    {
        return await (await HttpClient.PostAsJsonAsync("/Genres", genre)).Content.ReadFromJsonAsync<ActionResponse>();
    }

    public async Task<ActionResponse?> UpdateAsync(GenreEntity genre)
    {
        return await (await HttpClient.PutAsJsonAsync("/Genres", genre)).Content.ReadFromJsonAsync<ActionResponse>();
    }

    public async Task<ActionResponse?> DeleteAsync(int id)
    {
        return await (await HttpClient.DeleteAsync($"/Genres/{id}")).Content.ReadFromJsonAsync<ActionResponse>();
    }
}
