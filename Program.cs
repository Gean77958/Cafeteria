var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de OpenAPI
builder.Services.AddOpenApi();

// Configurar el puerto local
builder.WebHost.UseUrls("http://localhost:5168");

var app = builder.Build();

// Habilitar endpoint de OpenAPI en desarrollo
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Ruta principal de prueba
app.MapGet("/", () => "API Cafeteria funcionando");

// Ruta para obtener el listado de productos de cafetería
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
