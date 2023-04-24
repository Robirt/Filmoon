using Microsoft.Extensions.DependencyInjection;

namespace Filmoon;

public static class AppExtensions
{
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
        return services;
    }

    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        return services;
    }
}
