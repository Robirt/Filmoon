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
    public class UsersRepository
    {
        private HttpClient HttpClient { get; }

        public UsersRepository(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<List<UserEntity>> GetAsync()
        {
            return await HttpClient.GetFromJsonAsync<List<UserEntity>>("/Users");
        }

        public async Task<UserEntity> GetByIdAsync(int id)
        {
            return await HttpClient.GetFromJsonAsync<UserEntity>($"/Users/{id}");
        }
        public async Task AddAsync(UserEntity user)
        {
            await HttpClient.PostAsJsonAsync("/Users", user);
        }
        public async Task UpdateAsync(UserEntity user)
        {
            await HttpClient.PutAsJsonAsync("/Users", user);
        }
        public async Task DeleteAsync(int id)
        {
            await HttpClient.DeleteAsync($"/Users/{id}");
        }
    }
}

