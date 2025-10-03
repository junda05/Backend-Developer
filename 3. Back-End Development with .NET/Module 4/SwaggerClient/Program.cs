// http://localhost:5146

// Manually Client
// using System.Net;
// using System.Text.Json;

// var httpClient = new HttpClient();
// var apiBaseUrl = "http://localhost:5146";

// var httpResults = await httpClient.GetAsync($"{apiBaseUrl}/blogs");

// if (httpResults.StatusCode != HttpStatusCode.OK)
// {
//     Console.WriteLine("Failed to fetch blogs");
//     return;
// }

// var blogSteam = await httpResults.Content.ReadAsStreamAsync();

// var options = new JsonSerializerOptions
// {
//     PropertyNameCaseInsensitive = true
// };

// var blogs = await JsonSerializer.DeserializeAsync<List<Blog>>(blogSteam, options);

// if (blogs != null)
// {
//     foreach (var blog in blogs)
//     {
//         Console.WriteLine($"{blog.Title}: {blog.Body}");
//     }   
// }



// Swagger Client
using BlogApi;

// Once
// await new SwaggerClientGenerator().GenerateClient();

var httpClient = new HttpClient();
var apiBaseUrl = "http://localhost:5146";

var client = new BlogApiClient(apiBaseUrl, httpClient);
var blogs = await client.BlogsAllAsync();

// Delete a blog
await client.BlogsDELETEAsync(0);

foreach (var blog in blogs)
{
    Console.WriteLine($"{blog.Title}: {blog.Body}");
}