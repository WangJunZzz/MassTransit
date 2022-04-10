using System.Text.Json;
using MassTransit.Producer.Eto;

namespace MassTransit.Producer;

public class Worker : BackgroundService
{
    private readonly IBus  _publishEndpoint;
    private readonly ILogger<Worker> _logger;

    public Worker( ILogger<Worker> logger, IBus publishEndpoint)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var @event = new OrderEto()
            {
                Id = Guid.NewGuid(),
                Name = "Phone",
                CreationTime = DateTime.Now
            };
            await _publishEndpoint.Publish(@event, stoppingToken);
            _logger.LogInformation($"发送消息:{JsonSerializer.Serialize(@event)}");
            await Task.Delay(1000, stoppingToken);
        }
    }
}