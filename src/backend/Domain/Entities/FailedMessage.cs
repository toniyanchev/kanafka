using Kanafka.Admin.Domain.Enums;

namespace Kanafka.Admin.Domain.Entities;

public class FailedMessage
{
    public required Guid Id { get; set; }

    public required FailedMessageState State { get; set; }
    
    public required DateTime FailedOn { get; set; }

    public required string Topic { get; set; }

    public required Guid MessageId { get; set; }

    public required string MessageBody { get; set; }
    
    public string? MessageHeaders { get; set; }

    public string? ExceptionType { get; set; }

    public string? ExceptionMessage { get; set; }

    public string? ExceptionStackTrace { get; set; }
    
    public string? InnerExceptionType { get; set; }

    public string? InnerExceptionMessage { get; set; }

    public required int Retries { get; set; }

    public DateTime? ArchivedOn { get; set; }
}