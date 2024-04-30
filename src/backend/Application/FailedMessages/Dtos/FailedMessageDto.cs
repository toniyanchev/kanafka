namespace Kanafka.Admin.Application.FailedMessages.Dtos;

public class FailedMessageDto
{
    public Guid Id { get; set; }

    public DateTime FailedOn { get; set; }

    public string Topic { get; set; }

    public Guid MessageId { get; set; }

    public int Retries { get; set; }
}