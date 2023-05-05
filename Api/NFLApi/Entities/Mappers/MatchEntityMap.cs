using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class MatchEntityMap : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.ToTable("Matches");

        builder.HasKey(m => m.MatchId);

        builder.Property(m => m.MatchDate)
            .HasColumnType("date")
            .IsRequired();

        builder.HasOne(m => m.AwayTeam)
            .WithMany(t => t.AwayMatches)
            .HasForeignKey(m => m.AwayTeamCode)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.HomeTeam)
            .WithMany(t => t.HomeMatches)
            .HasForeignKey(m => m.HomeTeamCode)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.Stadium)
            .WithMany(s => s.MatchesPlayedInThisStadium)
            .HasForeignKey(m => m.StadiumId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.Property(m => m.MatchId)
            .HasColumnName("MatchID");

        builder.Property(m => m.AwayTeamCode)
            .HasColumnName("AwayTeam");

        builder.Property(m => m.HomeTeamCode)
            .HasColumnName("HomeTeam");

        builder.Property(m => m.StadiumId)
            .HasColumnName("Stadium");
    }
}