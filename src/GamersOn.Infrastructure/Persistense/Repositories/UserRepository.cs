using GamersOn.Domain.Entities;
using GamersOn.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamersOn.Infrastructure.Persistense.Repositories;
public class UserRepository : IUserRepository
{
    private readonly GamersOnContext _context;

    public UserRepository(GamersOnContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.AsNoTracking()
                                   .SingleOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
