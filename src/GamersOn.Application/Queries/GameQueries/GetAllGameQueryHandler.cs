using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using MediatR;

namespace GamersOn.Application.Queries.GameQueries;
public record struct GetAllGameQueryHandler : IRequestHandler<GetAllGameQuery, IEnumerable<Game>>
{
    private readonly IGameRepository _gameRepository;

    public GetAllGameQueryHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<IEnumerable<Game>> Handle(GetAllGameQuery request, CancellationToken cancellationToken)
    {
        return await _gameRepository.GetAllAsync();
    }
}
