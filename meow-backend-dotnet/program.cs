using PawsBackendDotnet.Models.Entities;
using PawsBackendDotnet.Extensions;
using PawsBackendDotnet.Extensions.ServicesExtensions;
using dotenv.net;
using PawsBackendDotnet.Services;
using PawsBackendDotnet.Services.Interfaces;


DotEnv.Load();
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices(builder.Configuration);

builder.Services.AddScoped<IJwtAuthService, JwtAuthService>();

WebApplication app = builder.Build();
app.UseAppMiddleware();

app.Run();

