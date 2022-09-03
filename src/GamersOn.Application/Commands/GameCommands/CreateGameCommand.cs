using ErrorOr;
using GamersOn.Application.OutputModels;
using MediatR;

namespace GamersOn.Application.Commands.GameCommands;
public record struct CreateGameCommand(string Name,
                                       string Description) : IRequest<ErrorOr<GameResponse>>;
