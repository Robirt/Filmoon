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
    public class RentalsRepository
    {
        private HttpClient HttpClient { get; }

        public RentalsRepository(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<List<RentalEntity>> GetAsync()
        {
            return await HttpClient.GetFromJsonAsync<List<RentalEntity>>("/Rentals");
        }

        public async Task<RentalEntity> GetByIdAsync(int id)
        {
            return await HttpClient.GetFromJsonAsync<RentalEntity>($"/Rentals/{id}");
        }
        public async Task AddAsync(RentalEntity rental)
        {
            await HttpClient.PostAsJsonAsync("/Rentals", rental);
        }
        public async Task UpdateAsync(RentalEntity rental)
        {
            await HttpClient.PutAsJsonAsync("/Rentals", rental);
        }
        public async Task DeleteAsync(int id)
        {
            await HttpClient.DeleteAsync($"/Rentals/{id}");
        }
    }
}
