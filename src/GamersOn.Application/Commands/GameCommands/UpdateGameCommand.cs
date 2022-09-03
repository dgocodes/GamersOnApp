using ErrorOr;
using GamersOn.Application.OutputModels;
using MediatR;

namespace GamersOn.Application.Commands.GameCommands;

public record struct UpdateGameCommand(Guid Id,
                                       string Name,
                                       string Description) : IRequest<ErrorOr<GameResponse>>;