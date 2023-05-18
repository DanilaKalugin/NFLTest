using Entities.Tables;
using Entities.Views;
using Microsoft.EntityFrameworkCore;

namespace Coursework.DAL
{
    public class CourseworkApplicationContext : DbContext
    {
        public CourseworkApplicationContext(DbContextOptions<CourseworkApplicationContext> options) : base(options)
        {

        }

        public DbSet<Team>? Teams { get; set; }
        public DbSet<Conference>? Conferences { get; set; }
        public DbSet<State>? States { get; set; }
        public DbSet<NationalDivision> Divisions { get; set; }
        public DbSet<TeamStandings> TeamStandings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get;set; }
        public DbSet<MatchResult> MatchResults { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<LastPlayedMatchId> MatchIds { get; set; }
        public DbSet<MatchTicket> Tickets { get; set; }
        public DbSet<PlayerInTeam> Players { get; set; }

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
            builder.ApplyConfiguration(new Entities.Mappers.UserEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.MatchTicketEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.PlayerInTeamEntityMap());

            builder.ApplyConfiguration(new Entities.Mappers.TeamStandingsViewMap());
            builder.ApplyConfiguration(new Entities.Mappers.LastPlayedMatchIdViewMap());
        }
    }
}