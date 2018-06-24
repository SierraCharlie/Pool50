using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

// ref: https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite

namespace Pool50.SQLite
{
    public class PoolContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

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

}