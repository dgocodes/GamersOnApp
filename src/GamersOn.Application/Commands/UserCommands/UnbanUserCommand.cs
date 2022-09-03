using ErrorOr;
using MediatR;

namespace GamersOn.Application.Commands.UserCommands;
public record struct UnbanUserCommand(Guid Id) : IRequest<ErrorOr<Task>>;

