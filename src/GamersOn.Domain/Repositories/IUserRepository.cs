using GamersOn.Domain.Entities;

namespace GamersOn.Domain.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task SaveChangesAsync();
}
