namespace MassTransit.Producer.Eto;

public class OrderEto
{
    public Guid Id { get; init; }

    public string Name { get; init; }
    
    public string Test { get; set; }

    public DateTime CreationTime { get; set; }
}