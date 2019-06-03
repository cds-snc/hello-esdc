using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HelloESDC.API.Models;

namespace HelloESDC.API.Database 
{
    public class HelloESDCContext : DbContext
    {

        public DbSet<Greeting> Greetings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseNpgsql(System.Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
        }
    }
}