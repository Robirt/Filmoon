using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Filmoon.Entities;

namespace Filmoon.Repositories;

public class DirectorsRepository
{
    private HttpClient HttpClient { get; }

    public DirectorsRepository(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public async Task<List<DirectorEntity>> GetAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<DirectorEntity>>("/Directors");
    }

    public async Task <DirectorEntity> GetByIdAsync(int id)
    {
        return await HttpClient.GetFromJsonAsync<DirectorEntity>($"/Directors/{id}");
    }
    public async Task AddAsync(DirectorEntity director)
    {
        await HttpClient.PostAsJsonAsync("/Directors", director);
    }
    public async Task UpdateAsync(DirectorEntity director)
    {
        await HttpClient.PutAsJsonAsync("/Directors", director);
    }
    public async Task DeleteAsync(int id)
    {
        await HttpClient.DeleteAsync($"/Directors/{id}");
    }

}
