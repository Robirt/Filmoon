using Filmoon.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Filmoon.Services;

public class ScreenwritersService
{
    public ScreenwritersService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task AddScreenwriterAsync(ScreenwriterEntity screenwriter)
    {
        await HttpClient.PostAsJsonAsync<ScreenwriterEntity>("/Screenwriters", screenwriter);
    }
}
