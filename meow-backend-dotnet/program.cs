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


app.MapGet("/mypet", () =>
{
    var newPet = new Pet
    {
        Name = "Whiskers",
        Type = "Cat",
        Breed = "Maine Coon",
        Sex = Sex.Male,
        ChipNumber = "123456789ABC",
        ImageUrl = "https://example.com/images/whiskers.jpg",
        BirthDate = new DateTime(2022, 5, 20),
        IsVaccine = true,
        LastFeed = DateTime.UtcNow.AddHours(-2),
        LastWalk = DateTime.UtcNow.AddHours(-5),
        LastMedication = DateTime.UtcNow.AddDays(-1)
    };
    return Results.Ok(newPet);
}).WithName("GetMyPet");




app.Run();

