using GamersOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamersOn.Infrastructure.Persistense.Configuration;

public class GameEvaluationConfiguration : IEntityTypeConfiguration<GameEvaluation>
{
    public void Configure(EntityTypeBuilder<GameEvaluation> builder)
    {
        builder.Property(x => x.Description)
               .HasColumnType("varchar")
               .HasMaxLength(500);

        //builder.HasOne(x => x.Game).WithMany(x => x.Evaluations).HasForeignKey(x => x.GameId);

        //builder.HasOne(x => x.User).WithOne();
    }
}
