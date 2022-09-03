using GamersOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GamersOn.Infrastructure.Persistense;

public class GamersOnContext : DbContext
{
    public GamersOnContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = default!;

    public DbSet<Game> Games { get; set; } = default!;

    public DbSet<GameEvaluation> GameEvaluation { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
