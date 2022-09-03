using MediatR;

namespace GamersOn.Application.Commands.GameCommands;
public record struct CreateGameCommand(string Name,
                                       string Description) : IRequest<Guid>;
