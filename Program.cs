var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }
        );
    }
);

var app = builder.Build();

app.UseCors();

app.MapGet("/", () =>
{
    return "API Polleria funcionando";
});

app.MapGet("/api/polleria", () =>
{
    return Results.Ok(new[]
    {
        new {
            id = 1,
            codigo = "P001",
            nombre = "Pollo a la brasa",
        },
        new {
            id = 2,
            codigo = "P002",
            nombre = "Pollo broaster",
        }
    });
});

// Lee la variable de entorno 'PORT' (ideal para deploys como Render/Heroku) o usa 5168 por defecto
var port = Environment.GetEnvironmentVariable("PORT") ?? "5168";

app.Run($"http://0.0.0.0:{port}");
