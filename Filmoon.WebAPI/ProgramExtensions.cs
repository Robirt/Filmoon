using Filmoon.Entities;
using Filmoon.Requests;
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
        options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Y14bFU89F2pQnfdnFHFH"));
        options.TokenValidationParameters.ValidateIssuerSigningKey = true;
        options.TokenValidationParameters.ValidIssuer = "Filmoon";
        options.TokenValidationParameters.ValidateIssuer = true;
        options.TokenValidationParameters.ValidateAudience = false;
        options.TokenValidationParameters.ValidateLifetime = true;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<UsersRepository>();
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
        services.AddScoped<ScreenwritersService>();
        services.AddScoped<DirectorsService>();
        services.AddScoped<MoviesService>();
        services.AddScoped<RentalsService>();

        return services;
    }

    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
    {
        var serviceScope = app.ApplicationServices.CreateScope();

        var filmoonContext = serviceScope.ServiceProvider.GetRequiredService<FilmoonContext>();

        filmoonContext.Database.Migrate();

        filmoonContext.Roles.AddRange(new RoleEntity() { Name = "Administrator" }, new RoleEntity() { Name = "Customer" });
        filmoonContext.SaveChanges();

        return app;
    }

    public static async Task<IApplicationBuilder> AddSuperAdministrator(this IApplicationBuilder app, IConfigurationSection superAdministratorCredentials)
    {
        var serviceScope = app.ApplicationServices.CreateScope();

        var administratorsService = serviceScope.ServiceProvider.GetRequiredService<AdministratorsService>();
        
        await administratorsService.AddAsync(new SignUpRequest(superAdministratorCredentials["UserName"]!, superAdministratorCredentials["Password"]!, superAdministratorCredentials["Email"]!));

        return app;
    }
}
