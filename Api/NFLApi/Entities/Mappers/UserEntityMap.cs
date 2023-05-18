using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class UserEntityMap: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.UserId);

        builder.HasAlternateKey(u => u.Email);

        builder.Property(u => u.Email)
            .HasMaxLength(100);

        builder.Property(u => u.Password)
            .HasMaxLength(150);

        builder.Property(u => u.FavoriteTeamAbbreviation)
            .HasColumnName("FavoriteTeam");

        builder.HasOne(u => u.FavoriteTeam)
            .WithMany(t => t.Users)
            .HasForeignKey(u => u.FavoriteTeamAbbreviation)
            .OnDelete(DeleteBehavior.Cascade);
    }
}