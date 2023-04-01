var webApplicationBuilder = WebApplication.CreateBuilder();

webApplicationBuilder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

webApplicationBuilder.Services.AddAuthentication();

webApplicationBuilder.Services.AddAuthorization();

webApplicationBuilder.Services.AddControllers();

var webApplication = webApplicationBuilder.Build();

webApplication.UseHttpsRedirection();

webApplication.UseAuthentication();

webApplication.UseAuthorization();

webApplication.MapControllers();

webApplication.Run();
