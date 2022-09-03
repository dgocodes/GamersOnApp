using ErrorOr;
using GamersOn.Application.OutputModels;
using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using MediatR;

namespace GamersOn.Application.Commands.GameCommands;

public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, ErrorOr<GameResponse>>
{
    private readonly IGameRepository _gameRepository;

    public UpdateGameCommandHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<ErrorOr<GameResponse>> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        if(await _gameRepository.GetByIdAsync(request.Id) is not Game game)
        {
            return Domain.Common.Errors.Application.NotFound(request.Id, nameof(Game));
        }

        game.Update(request.Name,
                    request.Description);

        await _gameRepository.SaveChangesAsync();

        return GameResponse.FromGame(game);
    }
}
