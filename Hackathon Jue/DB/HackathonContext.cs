using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Jue.DB
{
    public class HackathonContext : DbContext
    {
        public HackathonContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=POSTGRES_HOST;Port=5432;Database=POSTGRES_DB;Username=POSTGRES_USER;Password=POSTGRES_PASSWORD");
        }
    }
}
