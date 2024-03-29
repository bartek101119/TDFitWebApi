﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TDFitWebApi.Entities
{
    public class TDFitContext : DbContext
    {
        private string _connectionString = "Server=localhost;Database=TDFitDatabase;Trusted_Connection=True;";

        // tabele w bazie danych
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Diet> Diets { get; set; }

        public DbSet<Training> Trainings { get; set; }
       // public DbSet<Day> Days { get; set; }
        public DbSet<Calorie> Calories { get; set; }

        public DbSet<Summary> Summaries { get; set; }

        public DbSet<KeepDiet> KeepDiets { get; set; }

    


        // schemat bazy danych
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<KeepDiet>();

            modelBuilder.Entity<Summary>();

            modelBuilder.Entity<Training>();

            modelBuilder.Entity<Training>()
                 .HasOne(u => u.User);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role);
                
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
