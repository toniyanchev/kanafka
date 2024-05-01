using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Kanafka.Admin.Application;

public static class DependencyResolver
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(
            configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}