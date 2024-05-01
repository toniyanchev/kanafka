namespace Kanafka.Admin.Application.FailedMessages.Dtos;

/// <summary>
/// Data transfer object for failed message. Short segment of failed message data.
/// </summary>
public class FailedMessageShortDto
{
    /// <summary>
    /// Failed message id from the data source.
    /// </summary>
    public required Guid Id { get; set; }

    /// <summary>
    /// Date and time when the message failed.
    /// </summary>
    public required DateTime FailedOn { get; set; }

    /// <summary>
    /// Name of the kafka topic.
    /// </summary>
    public required string Topic { get; set; }

    /// <summary>
    /// Kafka message id.
    /// </summary>
    public required Guid MessageId { get; set; }

    /// <summary>
    /// The amount of retries for this failed message.
    /// </summary>
    public required int Retries { get; set; }
}