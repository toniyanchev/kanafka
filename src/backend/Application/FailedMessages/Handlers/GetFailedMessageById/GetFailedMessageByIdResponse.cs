using Kanafka.Admin.Application.FailedMessages.Dtos;

namespace Kanafka.Admin.Application.FailedMessages.Handlers.GetFailedMessageById;

/// <summary>
/// Mediatr response for GetFailedMessageById handler.
/// </summary>
public class GetFailedMessageByIdResponse
{
    public GetFailedMessageByIdResponse(FailedMessageDto? failedMessageDto)
    {
        FailedMessage = failedMessageDto;
    }

    /// <summary>
    /// Fetched failed message data transfer object. <see cref="FailedMessageDto"/>
    /// </summary>
    public FailedMessageDto? FailedMessage { get; set; }
}