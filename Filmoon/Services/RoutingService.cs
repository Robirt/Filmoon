using Filmoon.Models;
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

    public static List<RouteModel> Routes { get; private set; } = new()
    {
        new RouteModel("Home", new List<string> { "Customer" }),
        new RouteModel("Catalog", new List<string> { "Customer" }),
        new RouteModel("Contact", new List<string> { "Customer" }),
        new RouteModel("Movies", new List<string> { "Administrator" }),
        new RouteModel("Genres", new List<string> { "Administrator" }),
        new RouteModel("Screenwriters", new List<string> { "Administrator" }),
        new RouteModel("Directors", new List<string> { "Administrator" }),
        new RouteModel("Administrators", new List<string> { "Administrator" }),
        new RouteModel("Customers", new List<string> { "Administrator" }),
    };

    public void OnPageRequested(RouteModel route)
    {
        PageRequested?.Invoke(this, route);
    }

    public Page GetPage(RouteModel route)
    {
        var pageType = Type.GetType($"Filmoon.Views.Pages.{route.Name}Page, Filmoon");

        return (ServiceProvider.GetRequiredService(pageType!) as Page)!;
    }
}
