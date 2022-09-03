using GamersOn.Application.InputModels;
using GamersOn.Application.Queries.UserQueries;
using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using GamersOn.Infrastructure.Persistense;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamersOn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ApiController
{
    private readonly GamersOnContext _context;
    private readonly IUserRepository _userRepository;

    public UsersController(GamersOnContext context,
                           IUserRepository userRepository,
                           IMediator mediator) : base(mediator)
    {
        _context = context;
        _userRepository = userRepository;
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

        var id = await _mediator.Send(command);
    
        return CreatedAtAction(nameof(Get), new { id }, request);
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
}
