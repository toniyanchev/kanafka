using System.Text.Json;
using Kanafka.Admin.Application.FailedMessages.Producers;
using Kanafka.Admin.Domain;
using Kanafka.Admin.Domain.Entities;
using Kanafka.Admin.Domain.Messages;
using Kanafka.Producer;
using Kanafka.Utilities;

namespace Kanafka.Admin.Infrastructure.Core.Producers;

public class Reproducer : IReproducer
{
    private readonly IKanafkaProducer _kanafkaProducer;

    public Reproducer(IKanafkaProducer kanafkaProducer)
    {
        _kanafkaProducer = kanafkaProducer;
    }

    public async Task SendToReproducerAsync(List<Guid> failedMessageIds, CancellationToken cancellationToken)
    {
        var message = new ReproduceMessage
        {
            FailedMessageIds = failedMessageIds
        };

        var producingTasks = failedMessageIds.Select(_ =>
            _kanafkaProducer.SendAsync(Topics.ReproduceMessages, message, cancellationToken));

        await Task.WhenAll(producingTasks);
    }

    public async Task<bool> SendToTopicAsync(FailedMessage failedMessage, CancellationToken cancellationToken)
    {
        try
        {
            var kafkaMessage = MessageFactory.Create(failedMessage.MessageBody);
            var retries = failedMessage.Retries + 1;
            kafkaMessage.AddHeader("X-Retries", retries.ToString());

            if (!string.IsNullOrEmpty(failedMessage.MessageHeaders))
            {
                var existingHeaders =
                    JsonSerializer.Deserialize<Dictionary<string, string>>(failedMessage.MessageHeaders) ??
                    new Dictionary<string, string>();

                foreach (var existingHeader in existingHeaders.Where(x => x.Key != "X-Retries"))
                    kafkaMessage.AddHeader(existingHeader.Key, existingHeader.Value);
            }

            await _kanafkaProducer.SendAsync(failedMessage.Topic, kafkaMessage, cancellationToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}