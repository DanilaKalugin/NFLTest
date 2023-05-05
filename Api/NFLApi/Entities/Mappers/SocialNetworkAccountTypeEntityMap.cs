using Entities.Enums;
using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class SocialNetworkAccountTypeEntityMap: IEntityTypeConfiguration<SocialNetworkAccountType>
{
    public void Configure(EntityTypeBuilder<SocialNetworkAccountType> builder)
    {
        builder.ToTable("SocialNetworkAccountTypes");

        builder.HasKey(mt => mt.Id);

        builder.HasAlternateKey(mt => mt.Description);

        builder.Property(mt => mt.Id)
            .HasConversion<byte>();

        builder.HasData(
            Enum.GetValues(typeof(SocialNetworkAccountTypeEnum))
                .Cast<SocialNetworkAccountTypeEnum>()
                .Select(e => new SocialNetworkAccountType
                {
                    Id = e,
                    Description = e.ToString()
                })
        );

        builder.Property(bh => bh.Description)
            .HasMaxLength(30)
            .IsRequired();
    }
}