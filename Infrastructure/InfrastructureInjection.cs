using System.Text.Json.Serialization;
using Infrastructure.Interfaces;
using Infrastructure.Services.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureInjection
{   
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}