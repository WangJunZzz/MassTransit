namespace MassTransit.Consumer;

public class OrderEtoConsumerTwoDefinition : ConsumerDefinition<OrderEtoTwoConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<OrderEtoTwoConsumer> consumerConfigurator)
    {
        endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
    }
}