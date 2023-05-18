using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class PlayerInTeamEntityMap: IEntityTypeConfiguration<PlayerInTeam>
{
    public void Configure(EntityTypeBuilder<PlayerInTeam> builder)
    {
        builder.ToTable("TeamDepthCharts");
        builder.HasKey(p => p.PlayerInTeamId);

        builder.HasAlternateKey(p => new { p.TeamAbbreviation, p.PlayerJerseyNumber });

        builder.Property(p => p.PlayerJerseyNumber)
            .IsRequired();

        builder.Property(p => p.PlayerName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.PlayerRole)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(p => p.PlayerPosition)
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(p => p.PlayerStatus)
            .HasMaxLength(15)
            .IsRequired();

        builder.HasOne(p => p.Team)
            .WithMany(t => t.Players)
            .HasForeignKey(p => p.TeamAbbreviation)
            .OnDelete(DeleteBehavior.Cascade);
    }
}