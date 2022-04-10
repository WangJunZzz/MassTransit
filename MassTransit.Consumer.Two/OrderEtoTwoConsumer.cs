using System.Text.Json;
using MassTransit.Producer.Eto;

namespace MassTransit.Consumer;

public class OrderEtoTwoConsumer : IConsumer<OrderEto>
{
    private readonly ILogger<OrderEtoTwoConsumer> _logger;

    public OrderEtoTwoConsumer(ILogger<OrderEtoTwoConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<OrderEto> context)
    {
        _logger.LogInformation($"MassTransit.Consumer.Two 收到消息:{JsonSerializer.Serialize(context.Message)}");
        return Task.CompletedTask;
    }
}