using ErrorOr;
using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using MediatR;

namespace GamersOn.Application.Queries.GameQueries;
public record struct GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, ErrorOr<Game?>>
{
    private readonly IGameRepository _gameRepository;

    public GetGameByIdQueryHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<ErrorOr<Game?>> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        if (await _gameRepository.GetByIdAsync(request.Id) is not Game game)
        {
            return Domain.Common.Errors.Application.NotFound(request.Id, nameof(Game));
        }

        return game;
    }
}
