using System.Collections.Generic;
using HelloESDC.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloESDC.API.Database
{
    public class HelloESDCContext : DbContext
    {
        public DbSet<Greeting> Greetings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(System.Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Greeting>().HasIndex(g => g.Name).IsUnique();
        }
    }
}