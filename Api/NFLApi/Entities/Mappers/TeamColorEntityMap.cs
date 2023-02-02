using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class TeamColorEntityMap: IEntityTypeConfiguration<TeamColor>
{
    public void Configure(EntityTypeBuilder<TeamColor> builder)
    {
        builder.ToTable("teamColors");

        builder.HasKey(tc => new { tc.TeamAbbreviation, tc.ColorNumber });

        builder.Property(tc => tc.Color)
            .HasMaxLength(7)
            .IsRequired();

        builder.HasOne(tc => tc.Team)
            .WithMany(t => t.Colors)
            .HasForeignKey(tc => tc.TeamAbbreviation)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}