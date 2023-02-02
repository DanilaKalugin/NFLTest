using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class StateEntityMap:IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("States");

        builder.HasKey(s => s.StateCode);

        builder.Property(s => s.StateCode)
            .HasMaxLength(2);

        builder.Property(s => s.StateTitle)
            .HasMaxLength(30)
            .IsRequired();
    }
}