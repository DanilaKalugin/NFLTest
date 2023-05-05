using Entities.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers
{
    public class TeamStandingsViewMap : IEntityTypeConfiguration<TeamStandings>
    {
        public void Configure(EntityTypeBuilder<TeamStandings> builder)
        {
            builder.ToView("TeamStandings");
            builder.HasNoKey();
        }
    }
}