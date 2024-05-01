using MediatR;

namespace Kanafka.Admin.Application.FailedMessages.Handlers.ReproduceFailedMessages;

public class ReproduceFailedMessagesRequest : IRequest
{
    public IEnumerable<Guid> FailedMessageIds { get; set; } = new List<Guid>();
}