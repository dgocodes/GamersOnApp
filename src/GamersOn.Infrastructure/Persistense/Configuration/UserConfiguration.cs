using GamersOn.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GamersOn.Infrastructure.Persistense.Configuration;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Email)
               .HasColumnType("varchar")
               .HasMaxLength(40)
               .IsRequired();

        builder.Property(x => x.PasswordHash)
               .IsRequired();

        builder.Property(x => x.PasswordSalt)
               .IsRequired();

        builder.Property(x => x.IsBanned)
               .HasDefaultValue(false)
               .IsRequired();

        builder.Property(x => x.Active)
               .HasDefaultValue(true)
               .IsRequired();

        builder.HasQueryFilter(x => x.Active);
    }
}
