using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using GamersOn.Domain.Services;
using MediatR;

namespace GamersOn.Application.Commands.UserCommands;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashService _passwordHashGenerator;

    public CreateUserCommandHandler(IUserRepository userRepository,
                                    IPasswordHashService passwordHashGenerator)
    {
        _userRepository = userRepository;
        _passwordHashGenerator = passwordHashGenerator;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if(await _userRepository.GetByEmailAsync(request.Email) is User _)        
            throw new Exception($"Email {request.Email} ja cadastrado.");        

        _passwordHashGenerator.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var newUser = new User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        await _userRepository.CreateAsync(newUser);

        return newUser.Id;
    }
}
