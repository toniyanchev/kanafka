using MediatR;

namespace Kanafka.Admin.Application.FailedMessages.Handlers.ReproduceFailedMessagesPreparation;

/// <summary>
/// Mediatr request for ReproduceFailedMessagesPreparation handler.
/// </summary>
public class ReproduceFailedMessagesPreparationRequest : IRequest
{
    /// <summary>
    /// Ids (from the data source) of the messages to be reproduced
    /// </summary>
    public IEnumerable<Guid> FailedMessageIds { get; set; } = new List<Guid>();
}