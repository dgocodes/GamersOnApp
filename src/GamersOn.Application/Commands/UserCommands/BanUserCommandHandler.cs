using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using MediatR;

namespace GamersOn.Application.Commands.UserCommands;
public record struct BanUserCommandHandler : IRequestHandler<BanUserCommand, Task>
{
    private readonly IUserRepository _userRepository;

    public BanUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Task> Handle(BanUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByIdAsync(request.Id) is User user)
        {
            user.Ban();
            await _userRepository.SaveChangesAsync();
        }

        return Task.CompletedTask;
    }
}

