using Kanafka.Admin.Application.FailedMessages.Producers;
using Kanafka.Admin.Application.FailedMessages.Repositories;
using Kanafka.Admin.Domain.Enums;
using MediatR;

namespace Kanafka.Admin.Application.FailedMessages.Handlers.ReproduceFailedMessagesPreparation;

/// <summary>
/// Prepare failed messages to be reproduced.
/// <list type="bullet">
/// <item>Updates "state" property of the messages.</item>
/// <item>Produce kafka message to a topic which reproduces the failed messages.</item>
/// </list>
/// </summary>
public class ReproduceFailedMessagesPreparationHandler : IRequestHandler<ReproduceFailedMessagesPreparationRequest>
{
    private readonly IReproducer _reproducer;
    private readonly IFailedMessageRepository _failedMessageRepository;

    public ReproduceFailedMessagesPreparationHandler(
        IReproducer reproducer,
        IFailedMessageRepository failedMessageRepository)
    {
        _reproducer = reproducer;
        _failedMessageRepository = failedMessageRepository;
    }

    public async Task Handle(ReproduceFailedMessagesPreparationRequest request, CancellationToken cancellationToken)
    {
        await _failedMessageRepository.UpdateStateAsync(
            request.FailedMessageIds,
            FailedMessageState.Reproduced,
            cancellationToken);

        await _reproducer.SendToReproducerAsync(request.FailedMessageIds.ToList(), cancellationToken);
    }
}