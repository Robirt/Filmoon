using Filmoon.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Filmoon.Services;

public class DirectorsService
{
    public DirectorsService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task AddDirectorAsync(DirectorEntity director)
    {
        await HttpClient.PostAsJsonAsync<DirectorEntity>("/Directors", director);
    }
}
