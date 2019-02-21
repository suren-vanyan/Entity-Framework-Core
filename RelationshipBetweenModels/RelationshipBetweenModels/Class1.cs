using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipBetweenModels
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } // название команды

        public List<Player> Players { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string TeamName { get; set; }
        public Team Team { get; set; }
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
             .HasOne(p => p.Team)
             .WithMany(t => t.Players)
             .HasForeignKey(p => p.TeamName)
             .HasPrincipalKey(t => t.Name);
        }
    }
}
