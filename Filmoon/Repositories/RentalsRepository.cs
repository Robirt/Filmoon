using Filmoon.Entities;
using Filmoon.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Filmoon.Repositories;

public class RentalsRepository
{
    public RentalsRepository(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<RentalEntity>?> GetAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<RentalEntity>>("Rentals");
    }

    public async Task<RentalEntity?> GetByIdAsync(int id)
    {
        return await HttpClient.GetFromJsonAsync<RentalEntity>($"Rentals/{id}");
    }

    public async Task<ActionResponse?> AddAsync(RentalEntity rental)
    {
        return await (await HttpClient.PostAsJsonAsync("Rentals", rental)).Content.ReadFromJsonAsync<ActionResponse>();
    }

    public async Task<ActionResponse?> UpdateAsync(RentalEntity rental)
    {
        return await (await HttpClient.PutAsJsonAsync("Rentals", rental)).Content.ReadFromJsonAsync<ActionResponse>();
    }

    public async Task<ActionResponse?> RemoveAsync(int id)
    {
        return await (await HttpClient.DeleteAsync($"Rentals/{id}")).Content.ReadFromJsonAsync<ActionResponse>();
    }
}
