using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using MediatR;

namespace GamersOn.Application.Commands.GameCommands;

public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Task>
{
    private readonly IGameRepository _gameRepository;

    public UpdateGameCommandHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Task> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        if(await _gameRepository.GetByIdAsync(request.Id) is Game game)
        {
            game.Update(request.Name,
                        request.Description);

            await _gameRepository.SaveChangesAsync();
        }

        return Task.CompletedTask;
    }
}
