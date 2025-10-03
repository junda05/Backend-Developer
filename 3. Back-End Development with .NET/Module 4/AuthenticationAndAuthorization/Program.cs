var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else {
    app.UseDeveloperExceptionPage();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpLogging();

app.MapGet("/", () => "Hello World!");


// Implementing custom middleware starts by creating a class that defines the logic within the Invoke or InvokeAsync method.
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request Method: {context.Request.Method} - Request Path {context.Request.Path}");
    await next.Invoke();
    Console.WriteLine($"Response Status: {context.Response.StatusCode}");
});

app.Use(async(context, next) =>
{
    var startTime = DateTime.UtcNow;
    Console.WriteLine($"Start Time {startTime}");
    await next.Invoke();
    var duration = DateTime.UtcNow - startTime;
    Console.WriteLine($"Request took {duration.TotalMilliseconds} ms");
});

app.Run();