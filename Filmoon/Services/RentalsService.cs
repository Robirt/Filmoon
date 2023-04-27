using Filmoon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Filmoon.Services
{
    public class RentalsService
    {
        public RentalsService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        private HttpClient HttpClient { get; }

        public async Task AddRentalAsync(RentalEntity rental)
        {
            await HttpClient.PostAsJsonAsync<RentalEntity>("/Rentals", rental);
        }
    }
}
