using Filmoon.Repositories;
using Filmoon.Services;
using Filmoon.ViewModels;
using Filmoon.ViewModels.Pages;
using Filmoon.Views;
using Filmoon.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

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
        services.AddSingleton(provider => { return new HttpClient() { BaseAddress = new Uri("https://localhost:5000/WebAPI/") }; });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<RentalsRepository>();
        services.AddScoped<DirectorsRepository>();
        services.AddScoped<ScreenwritersRepository>();
        services.AddScoped<GenresRepository>();
        services.AddScoped<MoviesRepository>();
        services.AddScoped<AdministratorsRepository>();
        services.AddScoped<CustomersRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<UsersService>();

        services.AddScoped<RentalsService>();
        services.AddScoped<DirectorsService>();
        services.AddScoped<ScreenwritersService>();
        services.AddScoped<GenresService>();
        services.AddScoped<MoviesService>();
        services.AddScoped<AdministratorsService>();
        services.AddScoped<CustomersService>();

        return services;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();

        services.AddSingleton<SignInPageViewModel>();
        services.AddSingleton<SignUpPageViewModel>();

        services.AddSingleton<HomePageViewModel>();
        services.AddSingleton<CatalogPageViewModel>();
        services.AddSingleton<RentalsPageViewModel>();
        services.AddSingleton<MoviePageViewModel>();
        services.AddSingleton<DirectorsPageViewModel>();
        services.AddSingleton<ScreenwritersPageViewModel>();
        services.AddSingleton<GenresPageViewModel>();
        services.AddSingleton<MoviesPageViewModel>();
        services.AddSingleton<AdministratorsPageViewModel>();
        services.AddSingleton<CustomersPageViewModel>();

        return services;
    }

    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();

        services.AddSingleton<SignInPage>();
        services.AddSingleton<SignUpPage>();

        services.AddSingleton<HomePage>();
        services.AddSingleton<CatalogPage>();
        services.AddSingleton<ContactPage>();
        services.AddSingleton<ScreenwritersPage>();
        services.AddSingleton<DirectorsPage>();
        services.AddSingleton<GenresPage>();
        services.AddSingleton<MoviesPage>();
        services.AddSingleton<AdministratorsPage>();
        services.AddSingleton<CustomersPage>();

        return services;
    }
}
