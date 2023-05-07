using Filmoon.Commands;
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

        SignInRequest = new SignInRequest();

        SignInCommand = new SignInCommand(SignInAsync);
    }

    private UsersService UsersService { get; }
    private RoutingService RoutingService { get; }

    private SignInRequest signInRequest;
    public SignInRequest SignInRequest
    {
        get { return signInRequest; }
        set { SetProperty(ref signInRequest, value); }
    }

    private SignInResponse signInResponse;
    public SignInResponse SignInResponse
    {
        get { return signInResponse; }
        set { SetProperty(ref signInResponse, value); }
    }

    public ICommand SignInCommand { get; set; }

    private async void SignInAsync(object? parameter)
    {
        SignInResponse = await UsersService.SignInAsync((parameter as SignInRequest)!);
        if (SignInResponse.Succeeded)
        {
            RoutingService.OnPageRequested(new RouteModel("SignIn"));
        }
    }
}
