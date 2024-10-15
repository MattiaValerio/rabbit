using System.Text.Json.Serialization;
using Infrastructure.Interfaces;
using Infrastructure.Services.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureInjection
{   
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext.DataContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("postgresql"));
        });
        
        return services;
    }
}