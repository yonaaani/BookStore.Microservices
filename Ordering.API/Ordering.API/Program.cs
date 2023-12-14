using MediatR;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Behaviours;
using Ordering.Application.Contracts.Persistence;
using Ordering.Infrastructure.Persistence;
using Ordering.Infrastructure.Repositories;
using System.Data;
using System.Reflection;
using FluentValidation;
using Ordering.Application.Features.Commands.CheckoutOrder;
using Ordering.Application.Mappings;
using MassTransit;
using Ordering.API.EventBusConsumer;
using EventBus.Messages.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<OrderContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("SqlConnection"),
        new MySqlServerVersion(new Version(8, 0, 32)));
});
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

// MassTransit-RabbitMQ Configuration
builder.Services.AddMassTransit(config => {

    config.AddConsumer<BasketCheckoutConsumer>();

    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        cfg.UseHealthCheck(ctx);

        cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c => {
            c.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
        });
    });
});
builder.Services.AddMassTransitHostedService();

builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddMediatR(typeof(CheckoutOrderCommand).GetTypeInfo().Assembly);
builder.Services.AddMemoryCache();
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
