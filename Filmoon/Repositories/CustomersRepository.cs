using Filmoon.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Filmoon.Repositories;

public class CustomersRepository
{
    public CustomersRepository(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<CustomerEntity>?> GetAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<CustomerEntity>>("Customers");
    }
}
