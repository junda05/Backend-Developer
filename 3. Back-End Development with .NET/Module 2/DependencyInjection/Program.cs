var builder = WebApplication.CreateBuilder(args);

// Singleton service registration registers a single instance for the application's lifetime
// It is created the first time it is requested and the same instance is used for all subsequent requests
// builder.Services.AddSingleton<IMyService, MyService>();

// Scoped service registration creates a new instance for each client request
// The same instance is used within the scope of that request
// builder.Services.AddScoped<IMyService, MyService>();

// Transient service registration creates a new instance every time it is requested
// This is useful for lightweight, stateless services
builder.Services.AddTransient<IMyService, MyService>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("First middleware invoked.");
    await next.Invoke();
});

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Second middleware invoked.");
    await next.Invoke();
});

app.MapGet("/", (IMyService myService) =>
{
    myService.LogCreation("Handling request to '/' endpoint.");
    return Results.Ok("Check the console for service creation log.");
});

app.Run();

public interface IMyService
{
    void LogCreation(string message);
}

public class MyService : IMyService
{
    private readonly int _serviceId;

    public MyService()
    {
        _serviceId = new Random().Next(100000, 999999);
    }

    public void LogCreation(string message)
    {
        Console.WriteLine($"Service ID: {_serviceId}, Message: {message}");
    }
}