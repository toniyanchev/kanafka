using MediatR;

namespace Kanafka.Admin.Application.FailedMessages.Handlers.GetFailedMessageById;

/// <summary>
/// Mediatr request for GetFailedMessageById handler.
/// </summary>
public class GetFailedMessageByIdRequest : IRequest<GetFailedMessageByIdResponse>
{
    /// <summary>
    /// Id of the failed message from the data source.
    /// </summary>
    public Guid FailedMessageId { get; set; }
}