using ErrorOr;
using MediatR;

namespace GamersOn.Application.Commands.GameCommands;

public record struct DeleteGameCommand(Guid Id) : IRequest<ErrorOr<Task>>;

