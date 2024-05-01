using Kanafka.Admin.Application.FailedMessages.Handlers.GetFailedMessageById;
using Kanafka.Admin.Application.FailedMessages.Handlers.GetFailedMessagesList;
using Kanafka.Admin.Application.FailedMessages.Handlers.ReproduceFailedMessagesPreparation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kanafka.Admin.Api.Controllers;

/// <summary>
/// Controller to interact with failed messages.
/// </summary>
[ApiController]
[Route("[controller]/[action]")]
public class FailedMessagesController : Controller
{
    /// <summary>
    /// Mediatr sender interface.
    /// </summary>
    private readonly ISender _sender;

    public FailedMessagesController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Endpoint to fetch a failed message by id.
    /// </summary>
    /// <param name="request">Id of the failed message.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Status code 200 and as data - data transfer object of the failed message.</returns>
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] GetFailedMessageByIdRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Endpoint to fetch a paginated result for failed messages.
    /// </summary>
    /// <param name="request">The pagination request of type <see cref="GetFailedMessagesListRequest"/></param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Status code 200 and as data - paginated result <see cref="GetFailedMessagesListResponse"/></returns>
    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetFailedMessagesListRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Endpoint to reproduce failed messages.
    /// </summary>
    /// <param name="request">List of ids of the failed messages to be reproduced.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Status code 200</returns>
    [HttpPost]
    public async Task<IActionResult> Reproduce(
        [FromBody] ReproduceFailedMessagesPreparationRequest request,
        CancellationToken cancellationToken)
    {
        await _sender.Send(request, cancellationToken);

        return Ok();
    }
}