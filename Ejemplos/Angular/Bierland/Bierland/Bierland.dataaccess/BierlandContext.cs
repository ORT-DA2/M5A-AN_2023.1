using Bierland.domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bierland.dataaccess
{
    public class BierlandContext : DbContext
    {
        public DbSet<Beer> Beers { get; set; }
        public DbSet<BeerFactory> BeerFactorys { get; set; }
        public DbSet<BeerPurchase> BeerPurchases { get; set; }
        public DbSet<Pub> Pubs { get; set; }
        public DbSet<BeerPubs> BeerPubs { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }

        public BierlandContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            //optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Many to many Beer-Purchase
            modelBuilder.Entity<BeerPurchase>()
                .HasKey(x => new { x.BeerId, x.PurchaseId });

            modelBuilder.Entity<BeerPurchase>()
                .HasOne(x => x.Beer)
                .WithMany(x => x.BeerPurchases)
                .HasForeignKey(x => x.BeerId);

            modelBuilder.Entity<BeerPurchase>()
                .HasOne(x => x.Purchase)
                .WithMany(x => x.BeerPurchases)
                .HasForeignKey(x => x.PurchaseId);

            //Many to many Beer-Pubs
            modelBuilder.Entity<BeerPubs>()
                .HasKey(x => new { x.BeerId, x.PubId });

            modelBuilder.Entity<BeerPubs>()
                .HasOne(x => x.Beer)
                .WithMany(x => x.BeerPubs)
                .HasForeignKey(x => x.BeerId);

            modelBuilder.Entity<BeerPubs>()
                .HasOne(x => x.Pub)
                .WithMany(x => x.BeerPubs)
                .HasForeignKey(x => x.PubId);
        }
    }
}
