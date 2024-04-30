using Kanafka.Admin.Application.FailedMessages.Dtos;
using Kanafka.Admin.Application.FailedMessages.Repositories;
using Kanafka.Admin.Domain.Entities;
using Kanafka.Admin.Domain.Enums;
using Kanafka.Admin.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanafka.Admin.Infrastructure.Postgres.Repositories;

public class FailedMessageRepository : IFailedMessageRepository
{
    private readonly KanafkaContext _kanafkaContext;

    public FailedMessageRepository(KanafkaContext kanafkaContext)
    {
        _kanafkaContext = kanafkaContext;
    }

    public async Task<PagedResult<FailedMessageDto>> GetPagedListAsync(
        PagedRequest pagedRequest,
        CancellationToken cancellationToken)
    {
        var query = _kanafkaContext.FailedMessages
            .OrderByDescending(x => x.FailedOn)
            .Where(x => x.State == FailedMessageState.New)
            .Select(x => new FailedMessageDto
            {
                Id = x.Id,
                FailedOn = x.FailedOn,
                Topic = x.Topic,
                MessageId = x.MessageId,
                Retries = x.Retries
            });

        var result = new PagedResult<FailedMessageDto>
        {
            CurrentPage = pagedRequest.PageNumber,
            PageSize = pagedRequest.PageSize,
            RowCount = await query.CountAsync(cancellationToken)
        };

        var pageCount = (double)result.RowCount / pagedRequest.PageSize;
        result.PageCount = (int)Math.Ceiling(pageCount);

        var skip = (pagedRequest.PageNumber - 1) * pagedRequest.PageSize;
        result.Results = await query
            .Skip(skip)
            .Take(pagedRequest.PageSize)
            .ToListAsync(cancellationToken);

        return result;
    }
}