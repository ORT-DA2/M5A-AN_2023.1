using Microsoft.EntityFrameworkCore;
using OTM.Entities;

namespace OTM.Context
{
    public class OTMContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }

        public OTMContext(DbContextOptions options) : base(options)
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
            documentModel.HasOne(x => x.User)
                .WithMany(x => x.Documents)
                .HasForeignKey(x => x.UserId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
