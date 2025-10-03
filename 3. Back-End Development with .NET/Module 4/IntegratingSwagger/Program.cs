using Microsoft.AspNetCore.Http.HttpResults;

// We need to install Swashbuckle.AspNetCore and Microsoft.AspNetCore.OpenApi

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var blogs = new List<Blog> {
    new Blog { Title = "First Post", Body = "This is my first blog post." },
    new Blog { Title = "Second Post", Body = "This is my second blog post." }
};

// Restricting Swagger middleware to the development environment ensures that sensitive information about the API isn't exposed when the application is live.   

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    var startTime = DateTime.UtcNow;
    await next.Invoke();
    var duration = DateTime.UtcNow - startTime;
    Console.WriteLine($"Request took {duration.TotalMilliseconds} ms");
});

// Custom middleware
// context is an object that provides information about the HTTP request, has some info about the response, 
// Also we have a method called next that calls the next middleware in the pipeline.
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
    Console.WriteLine($"Response: {context.Response.StatusCode}");
});

// app.UseWhen(
//     context => context.Request.Method != "GET",
//         appBuilder => appBuilder.Use(async(context, next) =>
//         {
//             string apiKey = "ThisIsaBadPassword";
//             var extratedPassword = context.Request.Headers["X-Api-Key"];
//             if (string.IsNullOrEmpty(extratedPassword))
//             {
//                 context.Response.StatusCode = 401;
//                 await context.Response.WriteAsync("API Key is missing");
//             }
//             else if (extratedPassword == apiKey)
//             {
//                 await next.Invoke();
//             }
//             else
//             {
//                 context.Response.StatusCode = 401;
//                 await context.Response.WriteAsync("Invalid API Key");
//             }
//         })
// );

app.MapGet("/", () => "Hello World!").ExcludeFromDescription();

app.MapGet("/blogs", () =>
{
    return blogs;
});

app.MapGet("/blogs/{id}", Results<Ok<Blog>, NotFound> (int id) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return TypedResults.NotFound();
    }
    else
    {
        return TypedResults.Ok(blogs[id]);
    }
}).WithOpenApi(operation =>
{
    operation.Parameters[0].Description = "The ID of the blog to retrieve.";
    operation.Summary = "Get a single blog";
    operation.Description = "Returns a single blog";
    return operation;
});

app.MapPost("/blogs", (Blog blog) => {
    blogs.Add(blog);
    return Results.Created($"/blogs/{blogs.Count - 1}", blog);
});

app.MapDelete("/blogs/{id}", (int id) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }
    else
    {
        blogs.RemoveAt(id);
        return Results.NoContent();
    }
});

app.MapPut("/blogs/{id}", (int id, Blog blog) => {
    if (id < 0 || id >= blogs.Count) {
        return Results.NotFound();
    }
    else {
        blogs[id] = blog;
        return Results.Ok(blog);
    }
});

app.Run();