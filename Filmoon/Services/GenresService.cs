using Filmoon.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Filmoon.Services;

public class GenresService
{
    public GenresService( HttpClient httpClient) 
    {
            HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task AddGenreAsync(GenreEntity genre)
    {
        await HttpClient.PostAsJsonAsync<GenreEntity>("/Genres", genre);
    }
}
