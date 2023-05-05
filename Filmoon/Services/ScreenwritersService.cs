using Filmoon.Entities;
using Filmoon.Responses;
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

    public async Task<ActionResponse?> AddScreenwriterAsync(ScreenwriterEntity screenwriter)
    {
        return await (await HttpClient.PostAsJsonAsync("/Screenwriters", screenwriter)).Content.ReadFromJsonAsync<ActionResponse>();
    }
}
