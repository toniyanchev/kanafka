using Kanafka.Admin.Application.FailedMessages.Dtos;
using Kanafka.Admin.Domain.Models;

namespace Kanafka.Admin.Application.FailedMessages.Handlers.GetFailedMessagesList;

/// <summary>
/// Mediatr response for fetching paginated failed messages from the data source.
/// </summary>
public class GetFailedMessagesListResponse
{
    public GetFailedMessagesListResponse(PagedResult<FailedMessageDto> pagedResult)
    {
        PagedResult = pagedResult;
    }

    /// <summary>
    /// Pagination data model. See: <see cref="PagedResult"/>&lt;<see cref="FailedMessageDto"/>&gt;
    /// </summary>
    public PagedResult<FailedMessageDto> PagedResult { get; set; }
}