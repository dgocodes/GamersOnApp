using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GamersOn.Api.Controllers;


[ApiController]
public class ApiController : ControllerBase
{
    protected readonly IMediator _mediator;

    public ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
