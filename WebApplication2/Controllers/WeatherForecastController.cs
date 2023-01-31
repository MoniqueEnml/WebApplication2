using Microsoft.AspNetCore.Mvc;
using Exception = System.Exception;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Made call the weather end point");
        try
        { 
            throw new Exception("This is our login test exception");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),TemperatureC = Random.Shared.Next(-20, 55), Summary = Summaries[Random.Shared.Next(Summaries.Length)]}).ToArray();

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Fatal Error Occurred");
            throw;
        }
        
    }
}