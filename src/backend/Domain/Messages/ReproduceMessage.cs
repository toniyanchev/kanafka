namespace Kanafka.Admin.Domain.Messages;

public class ReproduceMessage
{
    public List<Guid> FailedMessageIds { get; set; } = new();
}