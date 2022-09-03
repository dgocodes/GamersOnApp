using GamersOn.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GamersOn.Infrastructure.Persistense.Configuration;

internal class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Description)
               .HasColumnType("varchar")
               .HasMaxLength(500);


        builder.HasMany(x => x.Evaluations)
               .WithOne()
               .HasForeignKey(x => x.GameId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
