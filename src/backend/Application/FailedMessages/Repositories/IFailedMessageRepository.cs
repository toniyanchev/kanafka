using Kanafka.Admin.Application.FailedMessages.Dtos;
using Kanafka.Admin.Domain.Models;

namespace Kanafka.Admin.Application.FailedMessages.Repositories;

/// <summary>
/// Repository to fetch data for failed kafka messages. Implementation is available for each Kanafka storage provider.
/// </summary>
public interface IFailedMessageRepository
{
    /// <summary>
    /// Fetches list of failed messages (in short format) from data source.
    /// </summary>
    /// <param name="pagedRequest">Pagination data model of type <see cref="PagedRequest"/>.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<PagedResult<FailedMessageDto>> GetPagedListAsync(
        PagedRequest pagedRequest,
        CancellationToken cancellationToken);
}