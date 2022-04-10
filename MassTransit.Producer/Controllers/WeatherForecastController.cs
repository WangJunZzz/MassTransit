using MassTransit.Producer.Eto;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit.Producer.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    //https://cloud.tencent.com/developer/article/1699711
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly IPublishEndpoint _publishEndpoint;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task Get()
    {
        await _publishEndpoint.Publish<OrderEto>(new OrderEto()
        {
            Id = Guid.NewGuid(),
            Name = "Phone"
        });
    }
}