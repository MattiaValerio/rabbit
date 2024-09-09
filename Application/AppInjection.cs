using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class AppInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(AppInjection).Assembly));
        return service;
    }
}