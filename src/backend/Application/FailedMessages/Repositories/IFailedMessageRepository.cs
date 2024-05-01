using Kanafka.Admin.Application.FailedMessages.Dtos;
using Kanafka.Admin.Domain.Entities;
using Kanafka.Admin.Domain.Enums;
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

    /// <summary>
    /// Fetches a failed messages by ids from the data source.
    /// </summary>
    /// <param name="ids">Ids of the failed messages from the data source.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of failed message entities. See - <see cref="FailedMessage"/></returns>
    Task<List<FailedMessage>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

    /// <summary>
    /// Updates the state of the failed messages.
    /// </summary>
    /// <param name="ids">Ids (from the data source) of the failed messages.</param>
    /// <param name="state">The new state.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task UpdateStateAsync(IEnumerable<Guid> ids, FailedMessageState state, CancellationToken cancellationToken);
}