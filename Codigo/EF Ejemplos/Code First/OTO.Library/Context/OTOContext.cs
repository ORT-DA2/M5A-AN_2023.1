using Microsoft.EntityFrameworkCore;
using OTO.Library.Entities;

namespace OTO.Library.Context
{
    public class OTOContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }

        public OTOContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USER
            var userModel = modelBuilder.Entity<User>();
            userModel.HasKey(x => x.Id);
            userModel.HasIndex(x => x.UserName).IsUnique();
            // DOCUMENT
            var documentModel = modelBuilder.Entity<Document>();
            documentModel.HasKey(x => x.Id);

            userModel
                .HasOne(x => x.Document)
                .WithOne(x => x.User)
                .HasForeignKey<Document>(x => x.UserId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
