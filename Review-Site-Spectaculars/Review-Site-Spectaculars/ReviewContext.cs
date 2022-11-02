using Microsoft.EntityFrameworkCore;
using Review_Site_Spectaculars.Models;
using System.Numerics;

namespace Review_Site_Spectaculars
{
    public class ReviewContext: DbContext
    {
        public DbSet<ReviewModel>? ReviewModel { get; set; }
        public DbSet<ProductModels>?ProductModels { get; set; }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ReviewSiteDb;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModels>().HasData( new ProductModels() { Id = 1, Name = "pizza" , Image= "Pic of Pizza", Description="very cheasy pizza"}
           );
            modelBuilder.Entity<ReviewModel>().HasData(new ReviewModel() { Id = 1, ReviewerName = "bob", Content = "i love the pizza " });
            base.OnModelCreating(modelBuilder);
        }
    }
}
