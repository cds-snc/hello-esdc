using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HelloESDC.API.Database 
{
    public class HelloESDCContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseNpgsql(System.Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
        }
    }
}