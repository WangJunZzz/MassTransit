using System.Reflection;
using MassTransit;
using MassTransit.Consumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMassTransit(x =>
{
    //x.AddConsumers(typeof(Program).Assembly);
    x.AddConsumer<OrderEtoConsumer>(typeof(OrderEtoConsumerDefinition));
    x.SetKebabCaseEndpointNameFormatter();
    //x.AddConsumer<OrderEtoConsumer, OrderEtoConsumerDefinition>();
    x.UsingRabbitMq((context, config) =>
    {
      
        config.Host("rabbitmq://localhost:5672", hostconfig =>
        {
            hostconfig.Username("admin");
            hostconfig.Password("admin");
        });
        
        config.ConfigureEndpoints(context);
       
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();