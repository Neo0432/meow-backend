using PawsBackendDotnet.Extensions;
using PawsBackendDotnet.Extensions.ServicesExtensions;
using dotenv.net;
using PawsBackendDotnet.Services;
using PawsBackendDotnet.Services.Interfaces;
using PawsBackendDotnet.Data;
using Microsoft.EntityFrameworkCore;

DotEnv.Load();
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);
builder.Services.AddScoped<IJwtAuthService, JwtAuthService>();

if (!builder.Environment.IsDevelopment())
{
    builder.WebHost.UseUrls("http://0.0.0.0:5062");
}

WebApplication app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PawsContext>();
    db.Database.Migrate();
}

app.UseAppMiddleware();
app.Run();

