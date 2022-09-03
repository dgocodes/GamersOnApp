using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using MediatR;

namespace GamersOn.Application.Commands.GameCommands;
public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Guid>
{
    private readonly IGameRepository _gameRepository;

    public CreateGameCommandHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var newGame = new Game
        {
            Name = request.Name,
            Description = request.Description
        };

        await _gameRepository.CreateAsync(newGame);

        return newGame.Id;
    }
}
