using GamersOn.Application.Commands.UserCommands;
using GamersOn.Application.InputModels;
using GamersOn.Application.Queries.UserQueries;
using GamersOn.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GamersOn.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ApiController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    // GET: api/<UsersController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetUserByIdQuery(id);

        if (await _mediator.Send(query) is User game)
        {
            return Ok(game);
        }

        return NotFound();
    }

    // POST api/<UsersController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserRequest request)
    {
        var command = request.ToCreateUserCommand();

        var result = await _mediator.Send(command);

        return result.Match(success => Ok(success), Problem);
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }

    // DELETE api/<UsersController>/5
    [HttpPut("{id}/ban")]
    public async Task<IActionResult> Ban([FromRoute] Guid id)
    {
        var command = new BanUserCommand(id);

        var result = await _mediator.Send(command);

        return result.Match(success => Ok(),
                            Problem);
    }

    // DELETE api/<UsersController>/5
    [HttpPut("{id}/unban")]
    public async Task<IActionResult> Unban([FromRoute] Guid id)
    {
        var command = new UnbanUserCommand(id);

        var result = await _mediator.Send(command);

        return result.Match(success => Ok(),
                            Problem);
    }

}
