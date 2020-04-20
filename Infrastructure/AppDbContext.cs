using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfolioItem>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Address>().ToTable("Addresses");
            modelBuilder.Entity<Owner>().HasData(
                   new Owner()
                   {
                       Id = Guid.NewGuid(),
                       Avatar = "avatar.jpg",
                       FullName = "Mohamed Ashraf",
                       Profil = ".NET Developer"
                   }
               );
        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PortfolioItem> portfolioItems { get; set; }

    }
}
