var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging((o) =>
{ 
    
});

var app = builder.Build();

// Add HTTP logging middleware to the pipeline
app.UseHttpLogging();
app.Use(async (context, next) =>
{
    await next.Invoke();
});
app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => "Hello Rote!");

app.Run();