using Filmoon.WebAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var webApplicationBuilder = WebApplication.CreateBuilder();

webApplicationBuilder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

webApplicationBuilder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.ConfigureJwtBearer());

webApplicationBuilder.Services.AddAuthorization();

webApplicationBuilder.Services.AddDbContext<FilmoonContext>();

webApplicationBuilder.Services.AddRepositories();

webApplicationBuilder.Services.AddControllers();

var webApplication = webApplicationBuilder.Build();

webApplication.UseHttpsRedirection();

webApplication.UseAuthentication();

webApplication.UseAuthorization();

webApplication.MigrateDatabase();

webApplication.MapControllers();

webApplication.Run();
