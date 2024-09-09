using Application.Services.Rabbit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application;

public static class AppInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddSingleton<RabbitService>();
        service.AddHostedService<RabbitListener>();
        service.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(AppInjection).Assembly));
        return service;
    }
}