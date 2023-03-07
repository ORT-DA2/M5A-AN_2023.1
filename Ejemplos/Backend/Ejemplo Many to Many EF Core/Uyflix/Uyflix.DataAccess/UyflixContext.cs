using Microsoft.EntityFrameworkCore;
using System;
using Uyflix.Domain.Entities;

namespace Uyflix.DataAccess
{
    public class UyflixContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MovieCategory> MoviesCategories { get; set; }
        public UyflixContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
                Relación many to many entre Category y Movie
                utilizando tabla intermedia MovieCategory.
            
             **RECORDAR**
                A partir de Entity Framework Core 5.0 
                ya no es necesario realizar una tabla intermedia.
             */
            modelBuilder.Entity<MovieCategory>()
                .HasKey(mc => new { mc.MovieId, mc.CategoryId });
            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MoviesCategories)
                .HasForeignKey(mc => mc.MovieId);
            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.Category)
                .WithMany(c => c.MoviesCategories)
                .HasForeignKey(mc => mc.CategoryId);
        }
    }
}
