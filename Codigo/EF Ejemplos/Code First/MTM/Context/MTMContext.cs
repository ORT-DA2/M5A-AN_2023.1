using Microsoft.EntityFrameworkCore;
using MTM.Entities;

namespace MTM.Context
{
    public class MTMContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<UserDocument> UserDocuments { get; set; }

        public MTMContext(DbContextOptions options) : base(options)
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
            // MTM
            var mtmModel = modelBuilder.Entity<UserDocument>();
            mtmModel.HasKey(x => new { x.UserId, x.DocumentId });
            mtmModel.HasOne(x => x.User)
                .WithMany(x => x.UserDocuments)
                .HasForeignKey(x => x.UserId);
            mtmModel.HasOne(x => x.Document)
                .WithMany(x => x.UserDocuments)
                .HasForeignKey(x => x.DocumentId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
