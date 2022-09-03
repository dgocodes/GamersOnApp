using MediatR;

namespace GamersOn.Application.Commands.UserCommands;
public record struct BanUserCommand(Guid Id) : IRequest<Task>;

