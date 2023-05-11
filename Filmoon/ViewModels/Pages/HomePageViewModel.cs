using Filmoon.Commands;
using Filmoon.Commands.Users;
using Filmoon.Models;
using Filmoon.Services;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class HomePageViewModel : ViewModelBase
{
    public HomePageViewModel(RoutingService routingService, UsersService usersService)
    {
        RoutingService = routingService;
        UsersService = usersService;

        GoToPageCommand = new GoToPageCommand(GoToPage);

        SignOutCommand = new SignOutCommand(SignOut);
    }

    private RoutingService RoutingService { get; }

    private UsersService UsersService { get; }

    public ICommand GoToPageCommand { get; set; }

    public ICommand SignOutCommand { get; set; }

    private void GoToPage(object? parameter)
    {
        RoutingService.OnPageRequested(new RouteModel((parameter as string)!));
    }

    private void SignOut()
    {
        UsersService.SignOutAsync();
    }
}
