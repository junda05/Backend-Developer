// Controllers bridge HTTP requests and the logic required to generate responses, making them essential to an API.

namespace MyFirstApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class WeatherForecast
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
}

[ApiController]
// Routing in ASP.NET Core directs incoming requests to the appropriate function or controller based on URL patterns and HTTP methods.
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[] {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        var rgn = new Random();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rgn.Next(-20, 55),
            Summary = Summaries[rgn.Next(Summaries.Length)]
        }).ToArray();
    }

    [HttpPost]
    public IActionResult Post([FromBody] WeatherForecast forecast)
    {
        return Ok(forecast);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] WeatherForecast forecast)
    {
        // Update data for the given ID
        // Example: Find and update an item with a matching ID
        // var existingForecast = /* fetch the data */;
        // existingForecast.Date = forecast.Date
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}