using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class DivisionEntityMap:IEntityTypeConfiguration<Division>
{
    public void Configure(EntityTypeBuilder<Division> builder)
    {
        builder.ToTable("Divisions");

        builder.HasKey(d => d.Number);

        builder.Property(d => d.Number)
            .HasColumnName("DivisionNumber");

        builder.Property(d => d.DivisionTitle)
            .HasMaxLength(40)
            .IsRequired();

        builder.HasOne(d => d.Conference)
            .WithMany(c => c.Divisions)
            .HasForeignKey(d => d.ConferenceId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}