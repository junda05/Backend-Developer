// The Program.cs file sets up the application’s configuration, services, and middleware pipeline, serving as the entry point for the application.
// Middleware components are processed in the order they are added, making sequencing critical for correct behavior.

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container
builder.Services.AddControllers();
var app = builder.Build();

// Habilitar Swagger solo en desarrollo (opcional)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
// Remove HTTPS redirection so you can test with http

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();