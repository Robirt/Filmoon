using Filmoon.Entities;
using Filmoon.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmoon.Services;

public class CustomersService
{
    public CustomersService(CustomersRepository customersRepository)
    {
        CustomersRepository = customersRepository;
    }

    private CustomersRepository CustomersRepository { get; }

    public async Task<List<CustomerEntity>?> GetAsync()
    {
        return await CustomersRepository.GetAsync();
    }
}
