using Kanafka.Admin.Application.FailedMessages.Producers;
using Kanafka.Admin.Application.FailedMessages.Repositories;
using Kanafka.Admin.Domain.Enums;
using MediatR;

namespace Kanafka.Admin.Application.FailedMessages.Handlers.ReproduceFailedMessages;

public class ReproduceFailedMessagesHandler : IRequestHandler<ReproduceFailedMessagesRequest>
{
    private readonly IFailedMessageRepository _failedMessageRepository;
    private readonly IReproducer _reproducer;

    public ReproduceFailedMessagesHandler(IFailedMessageRepository failedMessageRepository, IReproducer reproducer)
    {
        _failedMessageRepository = failedMessageRepository;
        _reproducer = reproducer;
    }

    public async Task Handle(ReproduceFailedMessagesRequest request, CancellationToken cancellationToken)
    {
        var failedMessages = await _failedMessageRepository.GetAsync(request.FailedMessageIds, cancellationToken);

        var sendingToTopicsTasks = failedMessages.ToDictionary(x => x.Id,
            y => _reproducer.SendToTopicAsync(y, cancellationToken));
        await Task.WhenAll(sendingToTopicsTasks.Values);

        var sendingToTopicsOutcome = sendingToTopicsTasks.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Result
        );

        var notSentIds = sendingToTopicsOutcome.Where(x => !x.Value).Select(x => x.Key).ToList();

        if (!notSentIds.Any())
            return;
        
        await _failedMessageRepository.UpdateStateAsync(
            notSentIds,
            FailedMessageState.NotReproduced,
            cancellationToken);
    }
}