using Kanafka.Admin.Application.FailedMessages.Repositories;
using MediatR;

namespace Kanafka.Admin.Application.FailedMessages.Handlers.GetFailedMessageById;

public class GetFailedMessageByIdHandler : IRequestHandler<GetFailedMessageByIdRequest, GetFailedMessageByIdResponse>
{
    private readonly IFailedMessageRepository _failedMessageRepository;

    public GetFailedMessageByIdHandler(IFailedMessageRepository failedMessageRepository)
    {
        _failedMessageRepository = failedMessageRepository;
    }

    public async Task<GetFailedMessageByIdResponse> Handle(
        GetFailedMessageByIdRequest request,
        CancellationToken cancellationToken)
    {
        var failedMessageDto = await _failedMessageRepository.GetAsync(request.FailedMessageId, cancellationToken);

        return new GetFailedMessageByIdResponse(failedMessageDto);
    }
}