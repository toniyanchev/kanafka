using Kanafka.Admin.Domain.Entities;

namespace Kanafka.Admin.Application.FailedMessages.Producers;

public interface IReproducer
{
    /// <summary>
    /// Send failed message ids to the Kanafka admin reproducing topic.
    /// </summary>
    /// <param name="failedMessageIds">List of failed message ids.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task SendToReproducerAsync(List<Guid> failedMessageIds, CancellationToken cancellationToken);

    /// <summary>
    /// Send a failed message to the topic where it has failed.
    /// </summary>
    /// <param name="failedMessage">Failed message entity instance. See - <see cref="FailedMessage"/></param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Boolean value:
    /// <list type="bullet">
    /// <item>true - sent successfully</item>
    /// <item>false - sent NOT successfully</item>
    /// </list>
    /// </returns>
    Task<bool> SendToTopicAsync(FailedMessage failedMessage, CancellationToken cancellationToken);
}