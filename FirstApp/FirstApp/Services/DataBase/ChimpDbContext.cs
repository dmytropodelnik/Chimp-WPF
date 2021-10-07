﻿using FirstApp.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Models.DataBase
{
    public class ChimpDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ChimpDbContext(DbContextOptions<ChimpDbContext> options) : base(options)
        {
            // If database already exists then delete it
            ConnectToDatabase();
        }

        /// <summary>
        ///     Try to connect to database. If fail then create new database.
        /// </summary>
        private void ConnectToDatabase()
        {
               // if (Database.CanConnect())
               // Database.EnsureDeleted();

            // Create database
            Database.EnsureCreated();
        }

        /// <summary>
        ///     Output in debug queries which are sent by EF in Output window (Menu Visual Studio: View -> Output).
        /// </summary>
        /// <param name="optionsBuilder">Builder options.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Method DbContextOptionsBuilder.LogTo was added only from EF Core 5.0.
            optionsBuilder.LogTo(s => System.Diagnostics.Debug.WriteLine(s));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersConfiguration());

        }
    }
}