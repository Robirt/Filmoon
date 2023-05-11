using Filmoon.Commands;
using Filmoon.Commands.Users;
using Filmoon.Models;
using Filmoon.Requests;
using Filmoon.Responses;
using Filmoon.Services;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class SignInPageViewModel : ViewModelBase
{
    public SignInPageViewModel(UsersService usersService, RoutingService routingService)
    {
        UsersService = usersService;
        RoutingService = routingService;

        SignInCommand = new SignInCommand(SignInAsync);

        GoToPageCommand = new GoToPageCommand(GoToPage);
    }

    private UsersService UsersService { get; }
    private RoutingService RoutingService { get; }

    private SignInRequest? signInRequest = new();
    public SignInRequest? SignInRequest
    {
        get { return signInRequest; }
        set { SetProperty(ref signInRequest, value); }
    }

    private SignInResponse? signInResponse = new();
    public SignInResponse? SignInResponse
    {
        get { return signInResponse; }
        set { SetProperty(ref signInResponse, value); }
    }

    public ICommand SignInCommand { get; set; }

    public ICommand GoToPageCommand { get; set; }

    private async void SignInAsync(object? parameter)
    {
        SignInResponse = await UsersService.SignInAsync((parameter as SignInRequest)!);

        SignInRequest = new SignInRequest();
    }

    private void GoToPage(object? parameter)
    {
        RoutingService.OnPageRequested(new RouteModel((parameter as string)!));
    }
}
