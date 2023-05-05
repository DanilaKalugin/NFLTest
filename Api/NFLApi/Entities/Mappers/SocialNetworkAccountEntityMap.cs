using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class SocialNetworkAccountEntityMap:IEntityTypeConfiguration<SocialNetworkAccount>
{
    public void Configure(EntityTypeBuilder<SocialNetworkAccount> builder)
    {
        builder.ToTable("SocialNetworkAccounts");
        builder.HasKey(sna => new { sna.TeamAbbreviation, sna.AccountTypeId });

        builder.Property(sna => sna.AccountAddress)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(sna => sna.Team)
            .WithMany(t => t.SocialNetworkAccounts)
            .HasForeignKey(sna => sna.TeamAbbreviation)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sna => sna.AccountType)
            .WithMany(snat => snat.Accounts)
            .HasForeignKey(sna => sna.AccountTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}