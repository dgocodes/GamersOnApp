using GamersOn.Domain.Entities;

namespace GamersOn.Application.OutputModels;

public record struct UserResponse(Guid Id, string Name, string Email)
{
    public static UserResponse FromUser(User user)
    {
        return new UserResponse(user.Id,
                                user.Name,
                                user.Email);
    }
}
