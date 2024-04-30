using Kanafka.Admin.Application.FailedMessages.Dtos;
using Kanafka.Admin.Domain.Models;

namespace Kanafka.Admin.Application.FailedMessages.Repositories;

public interface IFailedMessageRepository
{
    Task<PagedResult<FailedMessageDto>> GetPagedListAsync(
        PagedRequest pagedRequest,
        CancellationToken cancellationToken);
}