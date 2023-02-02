using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class ConferenceEntityMap: IEntityTypeConfiguration<Conference>
{
    public void Configure(EntityTypeBuilder<Conference> builder)
    {
        builder.ToTable("Conferences");
        
        builder.HasKey(c => c.ConferenceId);

        builder.HasAlternateKey(c => c.ConferenceName);

        builder.Property(c => c.ConferenceName)
            .HasMaxLength(75);

        builder.Property(c => c.ConferenceColor)
            .HasMaxLength(7)
            .IsRequired();
    }
}