using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDFitWebApi.Entities
{
    public class TDFitContext : DbContext
    {
        private string _connectionString = "Server=localhost;Database=TDFit;Trusted_Connection=True;";

        // tabele w bazie danych
        public DbSet<Diet> Diets { get; set; }
       // public DbSet<Day> Days { get; set; }
        public DbSet<Calorie> Calories { get; set; }

        // schemat bazy danych
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diet>()
                .HasMany(d => d.Calories)
                .WithOne(c => c.Diet);
                

           /* modelBuilder.Entity<Diet>()
                .HasMany(d => d.Days)
                .WithOne(d => d.Diet); */
        }
        
        // połączenie z bazą danych
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

        }

    }
}
