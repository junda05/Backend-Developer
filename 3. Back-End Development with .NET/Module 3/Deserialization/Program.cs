using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/auto", (Person personFromClient) =>
{
    return TypedResults.Ok(personFromClient);
});

app.MapPost("/manual", async (HttpContext context) =>
{
    var person = await context.Request.ReadFromJsonAsync<Person>();
    return TypedResults.Ok(person);
});

app.MapPost("/custom-options", async (HttpContext context) =>
{
    // Configura las opciones de deserialización JSON. En este caso,
    // se deshabilita la aceptación de miembros no mapeados, es decir, aquellos
    // que no están definidos en la clase Person.
    var options = new JsonSerializerOptions
    {
        UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
    };
    var person = await context.Request.ReadFromJsonAsync<Person>(options);
    return TypedResults.Ok(person);
});

app.MapPost("xml", async (HttpContext context) =>
{
    // Lee el cuerpo de la solicitud como una cadena
    var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();

    // Configura las opciones de deserialización JSON
    var xmlSerializer = new XmlSerializer(typeof(Person));
    var stringReader = new StringReader(body);

    // Deserializa el XML a un objeto Person
    var person = xmlSerializer.Deserialize(stringReader);
    return TypedResults.Ok(person);
});

app.Run();