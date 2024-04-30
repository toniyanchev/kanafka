using Kanafka.Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kanafka.Admin.Infrastructure.Postgres;

public sealed class KanafkaContext : DbContext
{
    public KanafkaContext(DbContextOptions<KanafkaContext> options) : base(options)
    {
    }

    public DbSet<FailedMessage> FailedMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("kanafka");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KanafkaContext).Assembly);
    }
}