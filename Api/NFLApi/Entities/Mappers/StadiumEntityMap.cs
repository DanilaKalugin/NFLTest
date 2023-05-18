using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class StadiumEntityMap:IEntityTypeConfiguration<Stadium>
{
    public void Configure(EntityTypeBuilder<Stadium> builder)
    {
        builder.ToTable("Stadiums");

        builder.HasKey(s => s.StadiumId);

        builder.HasAlternateKey(s => new{s.StadiumTitle, s.StadiumLocationId});

        builder.Property(s => s.StadiumId)
            .HasColumnType("smallint");

        builder.Property(s => s.StadiumLocationId)
            .HasColumnName("StadiumLocation");

        builder.Property(s => s.StadiumTitle)
            .IsRequired()
            .HasMaxLength(75);

        builder.HasOne(s => s.StadiumLocation)
            .WithMany(c => c.Stadiums)
            .HasForeignKey(s => s.StadiumLocationId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.Property(s => s.StadiumCapacity)
            .IsRequired();

        builder.Property(s => s.StadiumOpeningYear)
            .IsRequired();
    }
}