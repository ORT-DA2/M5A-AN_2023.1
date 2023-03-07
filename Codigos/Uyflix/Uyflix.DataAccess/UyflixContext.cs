using Microsoft.EntityFrameworkCore;
using Uyflix.Domain;

namespace Uyflix.DataAccess
{
    public class UyflixContext : DbContext
    {
        public UyflixContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Series> Series { get; set; }

        public virtual DbSet<Documentary> Documentaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
