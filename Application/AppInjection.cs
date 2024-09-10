using Application.Services.Ws;
using Infrastructure.Interfaces;
using Infrastructure.Services.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class AppInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
    {
        // Register RabbitMQ options
        var rabbitMqOptions = new RabbitOptions()
        {
            Host = configuration["RabbitMq:host"],
            QueName = configuration["RabbitMq:que"]
        };
        services.AddSingleton(rabbitMqOptions);

        // Register QueueService as IQueueService
        services.AddSingleton<IQueService, QueService>();
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(AppInjection).Assembly));
        
        // Register WebSocketHandler as a singleton
        services.AddSingleton<WsHandler>();
        
        return services;
    }
}