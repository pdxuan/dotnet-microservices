using BuildingBlocks.Logging;
using BuildingBlocks.Validation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace OrderingApplication
{
    public static class ApplicationFactory
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(ValidationService<,>));
                cfg.AddOpenBehavior(typeof(LoggingService<,>));
            });

            return services;
        }
    }
}
