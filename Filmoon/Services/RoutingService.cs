using Filmoon.Models;
using Filmoon.ViewModels;
using Filmoon.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Filmoon.Services;

public class RoutingService
{
    public RoutingService(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    private IServiceProvider ServiceProvider { get; }

    public event EventHandler<RouteModel>? PageRequested;

    public void OnPageRequested(RouteModel route)
    {
        PageRequested?.Invoke(this, route);
    }

    public static List<RouteModel> Routes { get; set; } = new()
    {
        new RouteModel("Home"),
        new RouteModel("Movies"),
        new RouteModel("Rentals"),
        new RouteModel("Contact"),
        new RouteModel("Users")
    };

    public Page GetPage(RouteModel route)
    {
        var pageType = Type.GetType($"Filmoon.Views.Pages.{route.Name}Page, Filmoon");

        if (pageType is null) return ServiceProvider.GetRequiredService<HomePage>();

        return (ServiceProvider.GetRequiredService(pageType) as Page)!;
    }
}
