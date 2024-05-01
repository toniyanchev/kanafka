using Kanafka.Admin.Application.FailedMessages.Repositories;
using Kanafka.Admin.Infrastructure.Postgres.Repositories;
using Kanafka.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kanafka.Admin.Infrastructure.Postgres;

public static class DependencyResolver
{
    public static void AddPostgresInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var pgConnString = configuration.GetConnectionString("KanafkaDb") ??
            throw new InvalidOperationException("Kanafka postgres db connection string was not provided.");

        services.AddKanafkaPostgres(new ProviderConfiguration(pgConnString));
        services.AddDbContext<KanafkaContext>(options =>
        {
            options
                .UseNpgsql(pgConnString)
                .UseSnakeCaseNamingConvention();
        });

        // Repositories
        services.AddScoped<IFailedMessageRepository, FailedMessageRepository>();
    }
}