using Kanafka.Admin.Domain.Entities;
using Kanafka.Admin.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kanafka.Admin.Infrastructure.Postgres.Mappings;

public class FailedMessageMapping : IEntityTypeConfiguration<FailedMessage>
{
    public void Configure(EntityTypeBuilder<FailedMessage> builder)
    {
        builder.ToTable("failed_messages");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.FailedOn).HasColumnType("timestamp");
        builder.Property(p => p.Topic).IsRequired();
        builder.Property(p => p.MessageId);
        builder.Property(p => p.MessageBody).HasColumnType("jsonb");
        builder.Property(p => p.MessageHeaders).HasColumnType("jsonb");
        builder.Property(p => p.ExceptionType);
        builder.Property(p => p.ExceptionMessage);
        builder.Property(p => p.ExceptionStackTrace);
        builder.Property(p => p.State).HasDefaultValue(FailedMessageState.New);
        builder.Property(p => p.Retries).HasDefaultValue(0);
        builder.Property(p => p.ArchivedOn).HasColumnType("timestamp");
    }
}