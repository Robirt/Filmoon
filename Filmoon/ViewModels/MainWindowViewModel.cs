using Filmoon.Models;
using Filmoon.Services;
using System.Collections.ObjectModel;

namespace Filmoon.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(RoutingService routingService)
    {
        RoutingService = routingService;

        Routes = new ObservableCollection<RouteModel>(RoutingService.Routes);
    }

    private RoutingService RoutingService { get; set; }

    public ObservableCollection<RouteModel> Routes { get; set; } = new ObservableCollection<RouteModel>();
}
