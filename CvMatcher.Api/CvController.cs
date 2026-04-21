using Microsoft.AspNetCore.Mvc;
using MediatR;
using CvMatcher.Application.Features.CvParsing.Commands;

[ApiController]
[Route("api/[controller]")]
public class CvController : ControllerBase
{
    private readonly IMediator _mediator;

    public CvController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadAndParseCv(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var command = new UploadAndParseCvCommand(file);
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}