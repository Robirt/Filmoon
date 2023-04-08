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
    public class ScreenwritersRepository
    {
        private HttpClient HttpClient { get; }

        public ScreenwritersRepository(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<List<ScreenwriterEntity>> GetAsync()
        {
            return await HttpClient.GetFromJsonAsync<List<ScreenwriterEntity>>("/Screenwriters");
        }

        public async Task<ScreenwriterEntity> GetByIdAsync(int id)
        {
            return await HttpClient.GetFromJsonAsync<ScreenwriterEntity>($"/Screenwriters/{id}");
        }
        public async Task AddAsync(ScreenwriterEntity screenwriter)
        {
            await HttpClient.PostAsJsonAsync("/Screenwriters", screenwriter);
        }
        public async Task UpdateAsync(ScreenwriterEntity screenwriter)
        {
            await HttpClient.PutAsJsonAsync("/Screenwriters", screenwriter);
        }
        public async Task DeleteAsync(int id)
        {
            await HttpClient.DeleteAsync($"/Screenwriters/{id}");
        }
    }
}
