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

        RoutingService.PageRequested += RoutingService_PageRequested;
    }

    private void RoutingService_PageRequested(object? sender, RouteModel route) => GoToPage(route);

    private UsersService UsersService { get; }
    private RoutingService RoutingService { get; }

    public ObservableCollection<RouteModel> Routes { get; set; } = new ObservableCollection<RouteModel>();

    private Page content = new();
    public Page Content
    {
        get { return content; }
        set { SetProperty(ref content, value); }
    }

    private void GoToPage(RouteModel route) => Content = RoutingService.GetPage(route);
}
