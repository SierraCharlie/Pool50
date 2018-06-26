using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

// ref: https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite
// Initialization: https://msdn.microsoft.com/en-us/magazine/mt788618.aspx

namespace Pool50.SQLite
{
    public class PoolContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int startId = 1;
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Arizona Cardinals" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Atlanta Falcons" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Baltimore Ravens" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Buffalo Bills" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Carolina Panthers" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Chicago Bears" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Cincinnati Bengals" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Cleveland Browns" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Dallas Cowboys" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Denver Broncos" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Detroit Lions" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Green Bay Packers" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Houston Texans" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Indianapolis Colts" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Jacksonville Jaguars" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Kansas City Chiefs" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Miami Dolphins" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Minnesota Vikings" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "New England Patriots" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "New Orleans Saints" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "New York Giants" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "New York Jets" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Oakland Raiders" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Philadelphia Eagles" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Pittsburgh Steelers" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "St. Louis Rams" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "San Diego Chargers" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "San Francisco 49ers" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Seattle Seahawks" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Tampa Bay Buccaneers" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Tennessee Titans" });
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = startId++, Name = "Washington Redskins" });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=pool.db");
        }
    }

    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }

    }

    public class Owner {
        public int OwnerId {get; set;}
        public int TeamId {get; set;}
        public Team Team {get; set;}
        public string Username {get; set;}
        public string FullName {get; set;}
    }

}