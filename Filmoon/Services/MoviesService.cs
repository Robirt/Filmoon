using Filmoon.Entities;
using Filmoon.Repositories;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Filmoon.Services
{
    public class MoviesService
    {
        public MoviesService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        private HttpClient HttpClient { get; }

        public async Task AddMovieAsync(MovieEntity genre)
        {
            await HttpClient.PostAsJsonAsync<MovieEntity>("/Movies", genre);
        }
    }
}
