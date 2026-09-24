var builder = WebApplication.CreateBuilder(args);

// Forzar que escuche en http://localhost:5168
builder.WebHost.UseUrls("http://localhost:5168");

var app = builder.Build();

app.MapGet("/", () => "API Cafeteria funcionando");

app.MapGet("/api/cafeteria", () =>
{
    return Results.Ok(new object[]
    {
        new {
            id = 1,
            codigo = "C001",
            nombre = "Cafe puro"
        },
        new {
            id = 12,
            codigo = "C002",
            nombre = "Capuchino"
        }
    });
});

app.Run();