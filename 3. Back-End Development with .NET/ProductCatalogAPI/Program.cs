// The Program.cs file sets up the application’s configuration, services, and middleware pipeline, serving as the entry point for the application.
// Middleware components are processed in the order they are added, making sequencing critical for correct behavior.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
// Remove HTTPS redirection so you can test with http

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();