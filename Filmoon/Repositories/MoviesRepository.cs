using Filmoon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Filmoon.Repositories
{
    public class MoviesRepository
    {
        private HttpClient HttpClient { get; }

        public MoviesRepository(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<List<MovieEntity>> GetAsync()
        {
            return await HttpClient.GetFromJsonAsync<List<MovieEntity>>("/Movies");
        }

        public async Task<MovieEntity> GetByIdAsync(int id)
        {
            return await HttpClient.GetFromJsonAsync<MovieEntity>($"/Movies/{id}");
        }
        public async Task AddAsync(MovieEntity movie)
        {
            await HttpClient.PostAsJsonAsync("/Movies", movie);
        }
        public async Task UpdateAsync(MovieEntity movie)
        {
            await HttpClient.PutAsJsonAsync("/Movies", movie);
        }
        public async Task DeleteAsync(int id)
        {
            await HttpClient.DeleteAsync($"/Movies/{id}");
        }
    }
}

