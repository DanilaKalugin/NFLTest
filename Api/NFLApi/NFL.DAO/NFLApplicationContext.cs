using Entities.Tables;
using Entities.Views;
using Microsoft.EntityFrameworkCore;

namespace NFL.DAO
{
    public class NFLApplicationContext : DbContext
    {
        public DbSet<Team>? Teams { get; set; }
        public DbSet<Conference>? Conferences { get; set; }
        public DbSet<State>? States { get; set; }
        public DbSet<NationalDivision> Divisions { get; set; }
        public DbSet<TeamStandings> TeamStandings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-I3JNR48\SQLEXPRESS;Initial Catalog=NFL_Test;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Entities.Mappers.StateEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.CityEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.ConferenceEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.StadiumEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.TeamEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.TeamColorEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.NationalDivisionEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.MatchEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.MatchResultEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.SocialNetworkAccountTypeEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.SocialNetworkAccountEntityMap());

            builder.ApplyConfiguration(new Entities.Mappers.TeamStandingsViewMap());
        }
    }
}