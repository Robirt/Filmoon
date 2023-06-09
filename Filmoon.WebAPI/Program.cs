using Filmoon.WebAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json.Serialization;

var webApplicationBuilder = WebApplication.CreateBuilder();

webApplicationBuilder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

webApplicationBuilder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.ConfigureJwtBearer());

webApplicationBuilder.Services.AddAuthorization();

webApplicationBuilder.Services.AddDbContext<FilmoonContext>();

webApplicationBuilder.Services.AddRepositories();

webApplicationBuilder.Services.AddServices();

webApplicationBuilder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var webApplication = webApplicationBuilder.Build();

webApplication.UseHttpsRedirection();

webApplication.UseAuthentication();

webApplication.UseAuthorization();

webApplication.MapControllers();

webApplication.MigrateDatabase();

await webApplication.AddSuperAdministrator(webApplication.Configuration.GetSection("SuperAdministratorCredentials"));

webApplication.Run();
