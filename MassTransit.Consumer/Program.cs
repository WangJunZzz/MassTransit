using System.Reflection;
using MassTransit;
using MassTransit.Consumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMassTransit(x =>
{
    
    // 通过扫描程序集注册消费者
    x.AddConsumers(typeof(Program).Assembly);
   
    // 通过类型单个注册消费者
    // x.AddConsumer<OrderEtoConsumer>(typeof(OrderEtoConsumerDefinition));
    
    // x.SetKebabCaseEndpointNameFormatter();
    
    // 通过泛型单个注册消费者
    //x.AddConsumer<OrderEtoConsumer, OrderEtoConsumerDefinition>();
    
    // 通过指定命名空间注册消费者
    // x.AddConsumersFromNamespaceContaining<OrderEtoConsumer>();
    
    // 使用内存队列
    // x.UsingInMemory();
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