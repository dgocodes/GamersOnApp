using GamersOn.Domain.Entities;

namespace GamersOn.Domain.Services;

public interface IAuthService
{
    string CreateToken(User user);
}

