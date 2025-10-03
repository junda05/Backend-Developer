

using NSwag;
using NSwag.CodeGeneration.CSharp;

public class SwaggerClientGenerator
{
    public async Task GenerateClient()
    {
        var apiBaseUrl = "http://localhost:5146";
        var httpClient = new HttpClient();
        var swaggerJson = await httpClient.GetStringAsync($"{apiBaseUrl}/swagger/v1/swagger.json");
        var document = await OpenApiDocument.FromJsonAsync(swaggerJson);

        var settings = new CSharpClientGeneratorSettings
        {
            ClassName = "BlogApiClient",
            CSharpGeneratorSettings = {
                Namespace = "BlogApi"
            }
        };

        var generator = new CSharpClientGenerator(document, settings);
        var code = generator.GenerateFile();
        await File.WriteAllTextAsync("BlogApiClient.cs", code);
    }
}