using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
	public class UyflixContext : DbContext
    {
        public UyflixContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Movie>? Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string directory = Directory.GetCurrentDirectory();

                IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(directory)
                 .AddJsonFile("appsettings.json")
                 .Build();

                var connectionString = configuration.GetConnectionString(@"UyflixDB");
                // var connectionString = configuration.GetConnectionString(@"UyflixDbORT");

                optionsBuilder.UseSqlServer(connectionString!);
            }
        }
    }
}

