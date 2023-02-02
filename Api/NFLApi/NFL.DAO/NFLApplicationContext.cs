using Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace NFL.DAO
{
    public class NFLApplicationContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Division> Divisions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-I3JNR48\SQLEXPRESS;Initial Catalog=NFL_Test;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Entities.Mappers.StateEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.CityEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.ConferenceEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.DivisionEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.StadiumEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.TeamEntityMap());
            builder.ApplyConfiguration(new Entities.Mappers.TeamColorEntityMap());
        }
    }
}