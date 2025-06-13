using meowBackendDotnet.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// app.MapGet("/weatherforecast", () =>
// {
//     // var forecast = Enumerable.Range(1, 5).Select(index =>
//     //     new WeatherForecast
//     //     (
//     //         DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//     //         Random.Shared.Next(-20, 55),
//     //         summaries[Random.Shared.Next(summaries.Length)]
//     //     ))
//     //     .ToArray();

//     var newPet = new Pet({BirthDate: DateTime.UtcNow,})
//     return newPet;
// })
// .WithName("GetWeatherForecast");
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

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
