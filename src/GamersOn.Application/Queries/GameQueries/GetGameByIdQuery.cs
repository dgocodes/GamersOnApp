using ErrorOr;
using GamersOn.Domain.Entities;
using MediatR;

namespace GamersOn.Application.Queries.GameQueries;

public record struct GetGameByIdQuery(Guid Id) : IRequest<ErrorOr<Game?>>;
