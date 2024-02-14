using Microsoft.EntityFrameworkCore;
using Overwatch_Match_Tracker.Model;

namespace Overwatch_Match_Tracker.Data
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Match> Matches { get; set; }
        public DbSet<QueueMode> QueueModes { get; set; }
        public DbSet<MatchResult> MatchResults  { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<GroupSize> GroupSizes { get; set; }
        public DbSet<Teammate> Teammates { get; set; }

        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OWMT.db;Trusted_Connection=True;");
        }
    }
}
