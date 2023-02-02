using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class CityEntityMap:IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");

        builder.HasKey(c => c.CityCode);

        builder.Property(c => c.CityTitle)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne(c => c.CityState)
            .WithMany(s => s.Cities)
            .HasForeignKey(c => c.CityStateId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}