using MassTransit.Producer.Eto;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit.Producer.Controllers;

[ApiController]
[Route("[controller]")]
public class PublishController : ControllerBase
{
    private readonly ILogger<PublishController> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public PublishController(ILogger<PublishController> logger, IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    public async Task Get()
    {
        await _publishEndpoint.Publish<OrderEto>(new OrderEto()
        {
            Id = Guid.NewGuid(),
            Name = "Phone",
            CreationTime = DateTime.Now
        });
    }
}