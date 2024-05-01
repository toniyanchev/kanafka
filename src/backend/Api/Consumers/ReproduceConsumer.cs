using Confluent.Kafka;
using Kanafka.Admin.Application.FailedMessages.Handlers.ReproduceFailedMessages;
using Kanafka.Admin.Domain.Messages;
using Kanafka.Consumer;
using Kanafka.Utilities;
using MediatR;

namespace Kanafka.Admin.Api.Consumers;

public class ReproduceConsumer : IKanafkaConsumer
{
    private readonly ISender _sender;

    public ReproduceConsumer(ISender sender)
    {
        _sender = sender;
    }

    public async Task ReceiveAsync(Message<string, string> message)
    {
        var reproduceMessage = message.GetContent<ReproduceMessage>();

        var reproduceFailedMessageRequest = new ReproduceFailedMessagesRequest
        {
            FailedMessageIds = reproduceMessage.FailedMessageIds
        };

        await _sender.Send(reproduceFailedMessageRequest);
    }
}