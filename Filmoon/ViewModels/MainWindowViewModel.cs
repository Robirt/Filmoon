using Filmoon.Commands;
using Filmoon.Commands.Users;
using Filmoon.Models;
using Filmoon.Responses;
using Filmoon.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace Filmoon.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(UsersService usersService, RoutingService routingService)
    {
        UsersService = usersService;
        RoutingService = routingService;

        GoToPageCommand = new GoToPageCommand(GoToPage);

        SignOutCommand = new SignOutCommand(SignOut);

        UsersService.SignedIn += UsersService_SignIn;
        UsersService.SignedOut += UsersService_SignOut;

        RoutingService.PageRequested += RoutingService_PageRequested;

        VerifySignIn();
    }

    private UsersService UsersService { get; }

    private RoutingService RoutingService { get; }

    private ObservableCollection<RouteModel> routes = new ObservableCollection<RouteModel>();
    public ObservableCollection<RouteModel> Routes
    {
        get { return routes; }
        set { SetProperty(ref routes, value); }
    }

    private Page content = new();
    public Page Content
    {
        get { return content; }
        set { SetProperty(ref content, value); }
    }

    public ICommand GoToPageCommand { get; set; }

    public ICommand SignOutCommand { get; set; }

    private void VerifySignIn()
    {
        if (string.IsNullOrEmpty(UsersService.JwtBearer.Name)) GoToPage("SignIn");
        else
        {
            Routes = new ObservableCollection<RouteModel>(RoutingService.Routes.Where(r => r.Roles.Contains(UsersService.JwtBearer.Role)));
            if (UsersService.JwtBearer.Role == "Administrator") GoToPage("Movies");
            else if (UsersService.JwtBearer.Role == "Customer") GoToPage("Home");
        }
    }

    private void GoToPage(string? paramater)
    {
        Content = RoutingService.GetPage(new RouteModel((paramater as string)!));
    }

    private void SignOut()
    {
        UsersService.SignOutAsync();

        Routes = new ObservableCollection<RouteModel>();
    }

    private void UsersService_SignIn(object? sender, SignInResponse e)
    {
        VerifySignIn();
    }

    private void UsersService_SignOut(object? sender, ActionResponse e)
    {
        GoToPage("SignIn");
    }

    private void RoutingService_PageRequested(object? sender, RouteModel route)
    {
        GoToPage(route.Name);
    }
}
