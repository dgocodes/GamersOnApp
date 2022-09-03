using GamersOn.Domain.Entities;
using MediatR;

namespace GamersOn.Application.Queries.UserQueries;
public record struct GetUserByIdQuery(Guid Id) : IRequest<User?>;
