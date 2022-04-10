namespace MassTransit.Producer.Eto;

public class OrderEto
{
    public Guid Id { get; init; }

    public string Name { get; set; }
    
    public DateTime CreationTime { get; set; }
}