using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Filmoon;

public partial class App : Application
{
    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, builder) => { builder.AddJsonFile("appsettings.json", true, true); })
            .ConfigureServices((context, services) => { services.AddRepositories().AddServices().AddViewModels().AddViews(); })
            .Build();
    }

    private IHost AppHost { get; }

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        await AppHost.StartAsync();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);

        await AppHost.StopAsync();
    }
}
