using System.Text.Json;
using MassTransit.Producer.Eto;

namespace MassTransit.Consumer;

public class OrderEtoConsumer : IConsumer<OrderEto>
{
    private readonly ILogger<OrderEtoConsumer> _logger;

    public OrderEtoConsumer(ILogger<OrderEtoConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<OrderEto> context)
    {
        _logger.LogInformation($"消费:{JsonSerializer.Serialize(context.Message)}");
        return Task.CompletedTask;
    }
}