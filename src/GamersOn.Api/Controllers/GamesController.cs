﻿using GamersOn.Application.Commands.GameCommands;
using GamersOn.Application.InputModels;
using GamersOn.Application.Queries.GameQueries;
using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using GamersOn.Infrastructure.Persistense;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GamersOn.Api.Controllers;

[Authorize]
[Route("api/games")]
public class GamesController : ApiController
{
    private readonly GamersOnContext _context;
    private readonly IGameRepository _gameRepository;

    public GamesController(GamersOnContext context,
                           IGameRepository gameRepository,
                           IMediator mediator) : base(mediator)
    {
        _context = context;
        _gameRepository = gameRepository;
    }


    #region "Games"

    // GET: api/<GamesController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllGameQuery();

        var result = await _mediator.Send(query);

        return result.Match(success => Ok(success), Problem);
    }

    // GET api/<GamesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetGameByIdQuery(id);

        var result = await _mediator.Send(query);

        return result.Match(success => Ok(success), Problem);
    }

    // POST api/<GamesController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GameRequest request)
    {
        var command = request.ToCreateGameCommand();

        var result = await _mediator.Send(command);

        return result.Match(success =>  CreatedAtAction(nameof(Get), new { success.Id }, success), Problem);
    }

    // PUT api/<GamesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] GameRequest request)
    {
        var command = request.ToUpdateGameCommand(id);

        var result = await _mediator.Send(command);

        return result.Match(success => Ok(success), Problem);
    }

    // DELETE api/<GamesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteGameCommand(id);

        var result = await _mediator.Send(command);

        return result.Match(success => NoContent(), Problem);
    }

    #endregion

    #region "Avaliações"

    [HttpPost("{id:guid}/evaluation")]
    public IActionResult Post([FromRoute] Guid id, [FromBody] GameEvaluationRequest request)
    {
        if (_context.Games.Include(x => x.Evaluations).FirstOrDefault(x => x.Id == id) is Game game)
        {

            var gameEvaluation = new GameEvaluation()
            {
                Description = request.Description,
                Rating = request.Rating,
                GameId = id
            };

            _context.GameEvaluation.Add(gameEvaluation);
            _context.SaveChanges();

            return RedirectToAction(nameof(Get), new { gameId = id, evaluationId = gameEvaluation.Id });
        }

        return NotFound();
    }


    [HttpGet("{gameId:guid}/evaluation/{evaluationId:guid}")]
    public IActionResult Get([FromRoute] Guid gameId, [FromRoute] Guid evaluationId)
    {
        if (_context.Games.Include(x => x.Evaluations.Where(x => x.Id == evaluationId))
                          .FirstOrDefault(x => x.Id == gameId) is Game game)
        {
            return Ok(game);
        }

        return NotFound();
    }


    [HttpDelete("{gameId:guid}/evaluation/{evaluationId:guid}")]
    public IActionResult Delete([FromRoute] Guid gameId, [FromRoute] Guid evaluationId)
    {
        if (_context.GameEvaluation.FirstOrDefault(x => x.Id == evaluationId && x.GameId == gameId) is GameEvaluation evaluation)
        {
            _context.GameEvaluation.Remove(evaluation);
            _context.SaveChanges();
            return NoContent();
        }

        return NotFound();
    }

    // PUT api/<GamesController>/5
    [HttpPut("{gameId:guid}/evaluation/{evaluationId:guid}")]
    public IActionResult Put([FromRoute] Guid gameId, [FromRoute] Guid evaluationId, GameEvaluationRequest request)
    {
        if (_context.GameEvaluation.FirstOrDefault(x => x.Id == evaluationId && x.GameId == gameId) is GameEvaluation gameUpdate)
        {
            gameUpdate.Rating = request.Rating;
            gameUpdate.Description = request.Description;

            _context.SaveChanges();

            return Ok(gameUpdate);
        }

        return NotFound($"Game not found for id {evaluationId}");
    }

    #endregion
}

