using GamersOn.Domain.Entities;

namespace GamersOn.Domain.Repositories;

public interface IGameRepository
{
    Task CreateAsync(Game game);
    Task UpdateAsync(Game game);
    Task DeleteAsync(Game game);
    Task<Game?> GetByIdAsync(Guid id);
    Task<List<Game>> GetAllAsync();
    Task SaveChangesAsync();
}

