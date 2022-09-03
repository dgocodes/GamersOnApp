using ErrorOr;
using GamersOn.Application.OutputModels;
using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using GamersOn.Domain.Services;
using MediatR;

namespace GamersOn.Application.Commands.UserCommands;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<UserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashService _passwordHashGenerator;

    public CreateUserCommandHandler(IUserRepository userRepository,
                                    IPasswordHashService passwordHashGenerator)
    {
        _userRepository = userRepository;
        _passwordHashGenerator = passwordHashGenerator;
    }

    public async Task<ErrorOr<UserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByEmailAsync(request.Email) is User _)
        {
            return Domain.Common.Errors.User.EmailAlreadyRegistered(request.Email);
        }   

        _passwordHashGenerator.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var newUser = new User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        await _userRepository.CreateAsync(newUser);

        return UserResponse.FromUser(newUser);
    }
}
