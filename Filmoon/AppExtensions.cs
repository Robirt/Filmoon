using Filmoon.Services;
using Filmoon.ViewModels;
using Filmoon.ViewModels.Pages;
using Filmoon.Views;
using Filmoon.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Filmoon;

public static class AppExtensions
{
    public static IServiceCollection AddRouting(this IServiceCollection services)
    {
        services.AddSingleton<RoutingService>();

        return services;
    }

    public static IServiceCollection AddHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient("HttpClient", httpClient => httpClient.BaseAddress = new Uri("https://localhost:5000/"));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();

        services.AddSingleton<HomePageViewModel>();

        return services;
    }

    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();

        services.AddSingleton<HomePage>();

        return services;
    }
}
