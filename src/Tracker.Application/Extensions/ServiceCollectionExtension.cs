using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Tracker.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ApplicationExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly);
        });

        return services;
    }
}
