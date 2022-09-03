using GamersOn.Application.OutputModels;
using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using GamersOn.Domain.Services;
using MediatR;

namespace GamersOn.Application.Commands.AuthenticationCommands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashService _passwordHashGenerator;
    private readonly IAuthService _authService;

    public LoginCommandHandler(IUserRepository userRepository,
                               IPasswordHashService passwordHashGenerator,
                               IAuthService authService)
    {
        _userRepository = userRepository;
        _passwordHashGenerator = passwordHashGenerator;
        _authService = authService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByEmailAsync(request.Email) is User user)
        {
            var passwordOk = _passwordHashGenerator.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);

            if (passwordOk)
            {
                var token = _authService.CreateToken(user);

                return new LoginResponse(token, UserResponse.FromUser(user));
            }
        }

        return new LoginResponse(string.Empty, null);
    }
}
