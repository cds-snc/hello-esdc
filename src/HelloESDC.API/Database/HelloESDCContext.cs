using System.Collections.Generic;
using HelloESDC.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloESDC.API.Database
{
    /// <summary>
    /// Database context for the Hello-ESDC app.
    /// </summary>
    public class HelloESDCContext : DbContext
    {
        /// <summary>
        /// Gets or sets the greeting db context.
        /// </summary>
        public DbSet<Greeting> Greetings { get; set; }

        /// <summary>
        /// Mechanism to configure the db context options.
        /// </summary>
        /// <param name="optionsBuilder">Container to store db access options.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(System.Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
        }

        /// <summary>
        ///  Mechanism to configure the db model.
        /// </summary>
        /// <param name="modelBuilder">Container to store and build the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Greeting>().HasIndex(g => g.Name).IsUnique();
        }
    }
}