using GamersOn.Application.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GamersOn.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    public AuthenticationController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AuthenticationRequest request)
    {
        var command = request.ToLoginCommand();

        var result = await _mediator.Send(command);

        return result.Match(success => Ok(success),
                            Problem);
    }
}
