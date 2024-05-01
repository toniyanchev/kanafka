namespace Kanafka.Admin.Application.FailedMessages.Dtos;

/// <summary>
/// Data transfer object for failed message. Extended segment of failed message data.
/// </summary>
public class FailedMessageDto : FailedMessageShortDto
{
    /// <summary>
    /// Content of the kafka message in JSON string format.
    /// </summary>
    public required string MessageBody { get; set; }
    
    /// <summary>
    /// Headers of the kafka message in JSON string format.
    /// </summary>
    public string? MessageHeaders { get; set; }

    /// <summary>
    /// The type of the exception that has been thrown when the message failed consumption.
    /// </summary>
    public string? ExceptionType { get; set; }

    /// <summary>
    /// The message of the exception that has been thrown when the message failed consumption.
    /// </summary>
    public string? ExceptionMessage { get; set; }

    /// <summary>
    /// The stack trace of the exception that has been thrown when the message failed consumption.
    /// </summary>
    public string? ExceptionStackTrace { get; set; }
    
    /// <summary>
    /// The type of the inner exception that has been thrown when the message failed consumption.
    /// </summary>
    public string? InnerExceptionType { get; set; }

    /// <summary>
    /// The message of the inner exception that has been thrown when the message failed consumption.
    /// </summary>
    public string? InnerExceptionMessage { get; set; }
    
    /// <summary>
    /// Date and time of the last archive of the failed message.
    /// </summary>
    public DateTime? ArchivedOn { get; set; }
}