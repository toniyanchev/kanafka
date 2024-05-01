using Kanafka.Admin.Application.FailedMessages.Repositories;
using Kanafka.Admin.Domain.Models;
using MediatR;

namespace Kanafka.Admin.Application.FailedMessages.Handlers.GetFailedMessagesList;

public class GetFailedMessagesListHandler : IRequestHandler<GetFailedMessagesListRequest, GetFailedMessagesListResponse>
{
    private readonly IFailedMessageRepository _failedMessageRepository;

    public GetFailedMessagesListHandler(IFailedMessageRepository failedMessageRepository)
    {
        _failedMessageRepository = failedMessageRepository;
    }

    public async Task<GetFailedMessagesListResponse> Handle(
        GetFailedMessagesListRequest request,
        CancellationToken cancellationToken)
    {
        var pagedRequest = new PagedRequest(request.PageNumber, request.PageNumber);
        var pagedResult = await _failedMessageRepository.GetPagedListAsync(pagedRequest, cancellationToken);

        return new GetFailedMessagesListResponse(pagedResult);
    }
}