using Kanafka.Admin.Application.FailedMessages.Repositories;
using Kanafka.Admin.Infrastructure.Postgres.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kanafka.Admin.Infrastructure.Postgres;

public static class DependencyResolver
{
    public static void AddPostgresInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        Console.WriteLine(configuration["Toni"]);
        var pgConnString = configuration.GetConnectionString("KanafkaDb") ??
            throw new InvalidOperationException("Kanafka postgres db connection string was not provided.");

        Console.WriteLine(configuration.GetConnectionString("KanafkaDb"));

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