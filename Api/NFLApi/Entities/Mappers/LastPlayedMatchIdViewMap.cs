using Entities.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class LastPlayedMatchIdViewMap : IEntityTypeConfiguration<LastPlayedMatchId>
{
    public void Configure(EntityTypeBuilder<LastPlayedMatchId> builder)
    {
        builder.ToView("IdForLastPlayedMatchForEveryTeam");
        builder.HasNoKey();
    }
}