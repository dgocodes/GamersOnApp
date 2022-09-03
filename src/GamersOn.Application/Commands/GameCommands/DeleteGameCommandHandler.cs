using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using MediatR;

namespace GamersOn.Application.Commands.GameCommands;

public record struct DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, Task>
{
    private readonly IGameRepository _gameRepository;

    public DeleteGameCommandHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Task> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        if (await _gameRepository.GetByIdAsync(request.Id) is Game game)
        {
            game.SetDisable();
            await _gameRepository.SaveChangesAsync();
        }

        return Task.CompletedTask;
    }
}

