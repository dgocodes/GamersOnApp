using GamersOn.Application.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GamersOn.Api.Controllers;

[Route("api/[controller]")]
public class AuthenticationController : ApiController
{
    public AuthenticationController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AuthenticationRequest request)
    {
        var command = request.ToLoginCommand();

        return Ok(await _mediator.Send(command));
    }
}
