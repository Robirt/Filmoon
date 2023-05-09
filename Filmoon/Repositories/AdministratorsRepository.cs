using Filmoon.Entities;
using Filmoon.Requests;
using Filmoon.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Filmoon.Repositories;

public class AdministratorsRepository
{
    public AdministratorsRepository(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<AdministratorEntity>?> GetAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<AdministratorEntity>>("Administrators");
    }

    public async Task<ActionResponse?> AddAsync(SignUpRequest signUpRequest)
    {
        return await (await HttpClient.PostAsJsonAsync("Administrators", signUpRequest)).Content.ReadFromJsonAsync<ActionResponse>();
    }
}
