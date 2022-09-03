using ErrorOr;
using GamersOn.Application.OutputModels;
using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using MediatR;

namespace GamersOn.Application.Queries.GameQueries;
public record struct GetAllGameQueryHandler : IRequestHandler<GetAllGameQuery, ErrorOr<IList<GameResponse>>>
{
    private readonly IGameRepository _gameRepository;

    public GetAllGameQueryHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<ErrorOr<IList<GameResponse>>> Handle(GetAllGameQuery request, CancellationToken cancellationToken)
    {
        if (await _gameRepository.GetAllAsync() is not IList<Game> games)
        {
            return Domain.Common.Errors.Application.NotFound(nameof(Game));
        }

        return GameResponse.FromGame(games).ToList();
    }
}
