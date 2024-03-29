﻿using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class MatchResultEntityMap : IEntityTypeConfiguration<MatchResult>
{
    public void Configure(EntityTypeBuilder<MatchResult> builder)
    {
        builder.ToTable("ResultsOfMatches");

        builder.HasKey(mr => mr.MatchId);

        builder.HasOne(mr => mr.Match)
            .WithOne(m => m.MatchResult)
            .HasForeignKey<MatchResult>(m => m.MatchId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(mr => mr.MatchWinner)
            .WithMany(t => t.MatchWinners)
            .HasForeignKey(mr => mr.MatchWinnerId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(mr => mr.MatchLoser)
            .WithMany(t => t.MatchLosers)
            .HasForeignKey(mr => mr.MatchLoserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(mr => mr.AwayTeamScore)
            .IsRequired();

        builder.Property(mr => mr.HomeTeamScore)
            .IsRequired();

        builder.Property(mr => mr.OvertimesCount)
            .HasDefaultValue(0)
            .IsRequired();
    }
}