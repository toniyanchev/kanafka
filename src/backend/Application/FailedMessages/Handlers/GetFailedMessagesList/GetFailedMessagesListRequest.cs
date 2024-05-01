using MediatR;

namespace Kanafka.Admin.Application.FailedMessages.Handlers.GetFailedMessagesList;

/// <summary>
/// Mediatr request for fetching paginated failed messages from the data source.
/// </summary>
public class GetFailedMessagesListRequest : IRequest<GetFailedMessagesListResponse>
{
    /// <summary>
    /// The number of the desired page.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// The size of the desired page.
    /// </summary>
    public int PageSize { get; set; }
}