using Filmoon.Commands.Rentals;
using Filmoon.Commands.Screenwriters;
using Filmoon.Entities;
using Filmoon.Responses;
using Filmoon.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class RentalsPageViewModel : ViewModelBase
{
    public RentalsPageViewModel(RentalsService rentalsService)
    {
        RentalsService = rentalsService;

        RemoveRentalCommand = new RemoveRentalCommand(RemoveRentalAsync);
    }

    private RentalsService RentalsService { get; }

    private List<RentalEntity>? rentals = new();
    public List<RentalEntity>? Rentals
    {
        get { return rentals; }
        set { SetProperty(ref rentals, value); }
    }

    private RentalEntity rental = new();
    public RentalEntity Rental
    {
        get { return rental; }
        set { SetProperty(ref rental, value); }
    }

    private ActionResponse? actionResponse = new();
    public ActionResponse? ActionResponse
    {
        get { return actionResponse; }
        set { SetProperty(ref actionResponse, value); }
    }

    public async Task GetRentals()
    {
        Rentals = await RentalsService.GetAsync();
    }

    public ICommand RemoveRentalCommand { get; set; }

    private async void RemoveRentalAsync(object? parameter)
    {
        ActionResponse = await RentalsService.RemoveAsync((parameter as RentalEntity)!);

        await GetRentals();

        Rental = new RentalEntity();
    }
}
