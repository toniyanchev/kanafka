using Kanafka.Admin.Application.FailedMessages.Dtos;
using Kanafka.Admin.Domain.Models;

namespace Kanafka.Admin.Application.FailedMessages.Repositories;

/// <summary>
/// Repository to fetch data for failed kafka messages. Implementation is available for each Kanafka storage provider.
/// </summary>
public interface IFailedMessageRepository
{
    /// <summary>
    /// Fetches list of failed messages (in short format) from the data source.
    /// </summary>
    /// <param name="pagedRequest">Pagination data model of type <see cref="PagedRequest"/>.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paginated result object <see cref="PagedRequest"/> with items of type <see cref="FailedMessageShortDto"/></returns>
    Task<PagedResult<FailedMessageShortDto>> GetPagedListAsync(
        PagedRequest pagedRequest,
        CancellationToken cancellationToken);

    /// <summary>
    /// Fetches a failed message by id from the data source.
    /// </summary>
    /// <param name="id">Id of the failed message from the data source.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Failed message data transfer object. See - <see cref="FailedMessageDto"/></returns>
    Task<FailedMessageDto?> GetAsync(Guid id, CancellationToken cancellationToken);
}