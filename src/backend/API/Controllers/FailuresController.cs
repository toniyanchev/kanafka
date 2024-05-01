using Kanafka.Admin.Application.FailedMessages.Handlers.GetFailedMessagesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kanafka.Admin.Api.Controllers;

/// <summary>
/// Controller to interact with failed messages.
/// </summary>
[ApiController]
[Route("[controller]/[action]")]
public class FailuresController : Controller
{
    /// <summary>
    /// Mediatr sender interface.
    /// </summary>
    private readonly ISender _sender;

    public FailuresController(ISender sender)
    {
        _sender = sender;
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