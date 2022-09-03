using ErrorOr;
using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using MediatR;

namespace GamersOn.Application.Commands.GameCommands;

public record struct DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, ErrorOr<Task>>
{
    private readonly IGameRepository _gameRepository;

    public DeleteGameCommandHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<ErrorOr<Task>> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        if (await _gameRepository.GetByIdAsync(request.Id) is not Game game)
        {
            return Domain.Common.Errors.Application.NotFound(request.Id, nameof(Game));
        }        

        game.Deactivate();
        await _gameRepository.SaveChangesAsync();

        return Task.CompletedTask;
    }
}

