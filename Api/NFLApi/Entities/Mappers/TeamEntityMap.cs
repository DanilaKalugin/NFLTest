using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class TeamEntityMap: IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams");
        builder.HasKey(t => t.TeamAbbreviation);

        builder.Property(t => t.TeamAbbreviation)
            .HasMaxLength(5);

        builder.Property(t => t.TeamRegion)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(t => t.TeamName)
            .HasMaxLength(35)
            .IsRequired();

        builder.HasOne(t => t.Stadium)
            .WithMany(s => s.Teams)
            .HasForeignKey(t => t.StadiumId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(t => t.Conference)
            .WithMany(c => c.Teams)
            .HasForeignKey(t => t.ConferenceId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired();

    }
}