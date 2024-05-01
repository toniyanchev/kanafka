using Kanafka.Admin.Application.FailedMessages.Producers;
using Kanafka.Admin.Infrastructure.Core.Producers;
using Kanafka.Admin.Infrastructure.Postgres;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kanafka.Admin.Infrastructure.Core;

public static class DependencyResolver
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IReproducer, Reproducer>();
        services.AddPostgresInfrastructureServices(configuration);
    }
}