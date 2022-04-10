namespace MassTransit.Consumer;

public class OrderEtoConsumerDefinition : ConsumerDefinition<OrderEtoConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<OrderEtoConsumer> consumerConfigurator)
    {
        endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
    }
}