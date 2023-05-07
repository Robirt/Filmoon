using Filmoon.Models;
using Filmoon.Services;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Filmoon.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(UsersService usersService, RoutingService routingService)
    {
        UsersService = usersService;
        RoutingService = routingService;

        UsersService.SignIn += UsersService_SignIn;
        UsersService.SignOut += UsersService_SignOut;

        RoutingService.PageRequested += RoutingService_PageRequested;

        VerifySignIn();
    }

    private void UsersService_SignIn(object? sender, Responses.SignInResponse e)
    {
        VerifySignIn();
    }

    private void UsersService_SignOut(object? sender, Responses.ActionResponse e)
    {
        GoToPage(new RouteModel("SignOut"));
    }

    private UsersService UsersService { get; }

    private RoutingService RoutingService { get; }

    public ObservableCollection<RouteModel> Routes { get; set; } = new ObservableCollection<RouteModel>();

    private Page content = new();
    public Page Content
    {
        get { return content; }
        set { SetProperty(ref content, value); }
    }

    public void VerifySignIn()
    {
        if (string.IsNullOrEmpty(UsersService.JwtBearer.Name)) GoToPage(new RouteModel("SignIn"));
        else GoToPage(new RouteModel("Home"));
    }

    private void GoToPage(RouteModel route) => Content = RoutingService.GetPage(route);

    private void RoutingService_PageRequested(object? sender, RouteModel route) => GoToPage(route);
}
