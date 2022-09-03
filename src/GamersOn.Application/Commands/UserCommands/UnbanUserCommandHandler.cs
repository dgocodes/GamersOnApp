using ErrorOr;
using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using MediatR;

namespace GamersOn.Application.Commands.UserCommands;
public record struct UnbanUserCommandHandler : IRequestHandler<UnbanUserCommand, ErrorOr<Task>>
{
    private readonly IUserRepository _userRepository;

    public UnbanUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Task>> Handle(UnbanUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByIdAsync(request.Id) is not User user)
        {
            return Domain.Common.Errors.Application.NotFound(request.Id, nameof(User));
        }

        user.Unban();

        await _userRepository.SaveChangesAsync();

        return Task.CompletedTask;
    }
}

