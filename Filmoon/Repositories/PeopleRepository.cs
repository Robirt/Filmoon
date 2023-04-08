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
    public class PeopleRepository
    {
        private HttpClient HttpClient { get; }

        public PeopleRepository(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<List<PersonEntity>> GetAsync()
        {
            return await HttpClient.GetFromJsonAsync<List<PersonEntity>>("/People");
        }

        public async Task<PersonEntity> GetByIdAsync(int id)
        {
            return await HttpClient.GetFromJsonAsync<PersonEntity>($"/People/{id}");
        }
        public async Task AddAsync(PersonEntity person)
        {
            await HttpClient.PostAsJsonAsync("/People", person);
        }
        public async Task UpdateAsync(PersonEntity person)
        {
            await HttpClient.PutAsJsonAsync("/People", person);
        }
        public async Task DeleteAsync(int id)
        {
            await HttpClient.DeleteAsync($"/People/{id}");
        }
    }
}
