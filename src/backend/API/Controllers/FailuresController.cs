using Kanafka.Admin.Application.FailedMessages.Repositories;
using Kanafka.Admin.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kanafka.Admin.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class FailuresController : Controller
{
    private readonly IFailedMessageRepository _failedMessageRepository;

    public FailuresController(IFailedMessageRepository failedMessageRepository)
    {
        _failedMessageRepository = failedMessageRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetList(int page, int size, CancellationToken cancellationToken)
    {
        //todo mediatr
        var t = await _failedMessageRepository.GetPagedListAsync(
            new PagedRequest(1, 1), cancellationToken);

        return Ok(t);
    }
}