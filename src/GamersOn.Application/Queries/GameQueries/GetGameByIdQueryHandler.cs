using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using MediatR;

namespace GamersOn.Application.Queries.GameQueries;
public record struct GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, Game?>
{
    private readonly IGameRepository _gameRepository;

    public GetGameByIdQueryHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Game?> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        if (await _gameRepository.GetByIdAsync(request.Id) is Game game)
        {
            return game;
        }

        return null;
    }
}
