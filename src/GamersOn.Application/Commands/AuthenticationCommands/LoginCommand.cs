using ErrorOr;
using GamersOn.Application.OutputModels;
using MediatR;

namespace GamersOn.Application.Commands.AuthenticationCommands;

public record struct LoginCommand(string Email, string Password) : IRequest<ErrorOr<LoginResponse>>;
