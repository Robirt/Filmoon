using Filmoon.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Filmoon.Repositories
{
    public class GenresRepository
    {
        private HttpClient HttpClient { get; }

        public GenresRepository(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<List<GenreEntity>> GetAsync()
        {
            return await HttpClient.GetFromJsonAsync<List<GenreEntity>>("/Genres");
        }

        public async Task<GenreEntity> GetByIdAsync(int id)
        {
            return await HttpClient.GetFromJsonAsync<GenreEntity>($"/Genres/{id}");
        }
        public async Task AddAsync(GenreEntity genre)
        {
            await HttpClient.PostAsJsonAsync("/Genres", genre);
        }
        public async Task UpdateAsync(GenreEntity genre)
        {
            await HttpClient.PutAsJsonAsync("/Genres", genre);
        }
        public async Task DeleteAsync(int id)
        {
            await HttpClient.DeleteAsync($"/Genres/{id}");
        }
    }
}
