using Filmoon.Commands.Users;
using Filmoon.Models;
using Filmoon.Requests;
using Filmoon.Responses;
using Filmoon.Services;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class SignUpPageViewModel : ViewModelBase
{
    public SignUpPageViewModel(UsersService usersService, RoutingService routingService)
    {
        UsersService = usersService;
        RoutingService = routingService;

        SignUpRequest = new SignUpRequest();

        SignUpCommand = new SignUpCommand(SignUpAsync);
    }

    private UsersService UsersService { get; }

    private RoutingService RoutingService { get; }

    private SignUpRequest signUpRequest = new();
    public SignUpRequest SignUpRequest
    {
        get { return signUpRequest; }
        set { SetProperty(ref signUpRequest, value); }
    }

    private ActionResponse? actionResponse = new();
    public ActionResponse? ActionResponse
    {
        get { return actionResponse; }
        set { SetProperty(ref actionResponse, value); }
    }

    public ICommand SignUpCommand { get; set; }

    private async void SignUpAsync(object? parameter)
    {
        ActionResponse = await UsersService.SignUpAsync((parameter as SignUpRequest)!);

        if (ActionResponse!.Succeeded) RoutingService.OnPageRequested(new RouteModel("SignIn"));
    }
}
