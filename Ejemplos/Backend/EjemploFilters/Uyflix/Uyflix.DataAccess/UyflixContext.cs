using Microsoft.EntityFrameworkCore;
using Uyflix.Domain.Entities;

namespace Uyflix.DataAccess
{
    public class UyflixContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public UyflixContext(DbContextOptions options) : base(options)
        {

        }
    }
}
