using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers
{
    public class NationalDivisionEntityMap : IEntityTypeConfiguration<NationalDivision>
    {
        public void Configure(EntityTypeBuilder<NationalDivision> builder)
        {
            
            builder.ToTable("NationalDivisions");

            builder.HasKey(d => d.DivisionId);
            builder.Property(d => d.DivisionTitle)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
