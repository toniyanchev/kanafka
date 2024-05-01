using Kanafka.Admin.Application.FailedMessages.Handlers.GetFailedMessageById;
using Kanafka.Admin.Application.FailedMessages.Handlers.GetFailedMessagesList;
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
    /// Endpoint to fetch a failed message by id from the data source.
    /// </summary>
    /// <param name="request">Id of the failed message from the data source.</param>
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
    /// Endpoint to fetch a paginated result for failed messages from the data source.
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
}