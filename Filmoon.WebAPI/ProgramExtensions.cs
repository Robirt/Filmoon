using Filmoon.WebAPI.Repositories;
using Filmoon.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Filmoon.WebAPI;

public static class ProgramExtensions
{
    public static void ConfigureJwtBearer(this JwtBearerOptions options)
    {
        options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));
        options.TokenValidationParameters.ValidateIssuerSigningKey = true;
        options.TokenValidationParameters.ValidIssuer = "";
        options.TokenValidationParameters.ValidateIssuer = true;
        options.TokenValidationParameters.ValidateAudience = false;
        options.TokenValidationParameters.ValidateLifetime = true;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<AdministratorsRepository>();
        services.AddScoped<CustomersRepository>();

        services.AddScoped<GenresRepository>();
        services.AddScoped<ScreenwritersRepository>();
        services.AddScoped<DirectorsRepository>();
        services.AddScoped<MoviesRepository>();
        services.AddScoped<RentalsRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<UsersService>();
        services.AddScoped<AdministratorsService>();
        services.AddScoped<CustomersService>();

        services.AddScoped<GenresService>();
        services.AddScoped<ScreenwritersRepository>();
        services.AddScoped<DirectorsService>();
        services.AddScoped<MoviesService>();
        services.AddScoped<RentalsService>();

        return services;
    }

    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        
        serviceScope.ServiceProvider.GetRequiredService<FilmoonContext>().Database.Migrate();

        return app;
    }
}
