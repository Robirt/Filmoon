using Filmoon.Entities;
using Filmoon.Responses;
using Filmoon.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmoon.ViewModels.Pages;

public class CustomersPageViewModel : ViewModelBase
{
    public CustomersPageViewModel(CustomersService customersService)
    {
        CustomersService = customersService;

        Customers.Add(new CustomerEntity() { Email = "Sasasa", UserName = "Customerek " });
    }

    private CustomersService CustomersService { get; }

    private List<CustomerEntity>? customers = new();
    public List<CustomerEntity>? Customers
    {
        get { return customers; }
        set { SetProperty(ref customers, value); }
    }

    private CustomerEntity customer = new();
    public CustomerEntity Customer
    {
        get { return customer; }
        set { SetProperty(ref customer, value); }
    }

    private ActionResponse? actionResponse = new();
    public ActionResponse? ActionResponse
    {
        get { return actionResponse; }
        set { SetProperty(ref actionResponse, value); }
    }

    public async Task GetCustomers()
    {
        //Customers = await CustomersService.GetAsync();
    }
}
