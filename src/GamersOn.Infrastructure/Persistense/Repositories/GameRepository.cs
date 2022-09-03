using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamersOn.Infrastructure.Persistense.Repositories;

public class GameRepository : IGameRepository
{
    private readonly GamersOnContext _context;

    public GameRepository(GamersOnContext context)
    {
        _context = context;
    }

    public Task CreateAsync(Game game)
    {
        _context.Games.Add(game);
        _context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Game game)
    {
        _context.Update(game);
        _context.SaveChanges();

        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Game game)
    {
        game.SetDisable();
        await _context.SaveChangesAsync();
    }

    public async Task<List<Game>> GetAllAsync()
    {
        return await _context.Games.AsNoTracking()
                                   .ToListAsync();
    }

    public async Task<Game?> GetByIdAsync(Guid id)
    {
        return await _context.Games.Include(x => x.Evaluations)
                                   .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
