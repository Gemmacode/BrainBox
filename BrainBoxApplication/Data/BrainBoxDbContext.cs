using BrainBoxApplication.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace BrainBoxApplication.Data
{
    public class BrainBoxDbContext : DbContext
    {
        public BrainBoxDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Products)
                .WithOne()
                .HasForeignKey(p => p.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

    }


}
