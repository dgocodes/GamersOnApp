using ErrorOr;
using GamersOn.Application.OutputModels;
using MediatR;

namespace GamersOn.Application.Queries.GameQueries;
public record struct GetAllGameQuery : IRequest<ErrorOr<IList<GameResponse>>>;
