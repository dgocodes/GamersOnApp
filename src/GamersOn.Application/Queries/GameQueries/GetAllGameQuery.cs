using GamersOn.Domain.Entities;
using MediatR;

namespace GamersOn.Application.Queries.GameQueries;
public record struct GetAllGameQuery : IRequest<IEnumerable<Game>>;
