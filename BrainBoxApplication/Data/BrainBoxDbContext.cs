using BrainBoxApplication.Data.DTO;
using BrainBoxApplication.Entity;
using Microsoft.EntityFrameworkCore;

namespace BrainBoxApplication.Data
{
    public class BrainBoxDbContext : DbContext
    {
        public BrainBoxDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItemss { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
        .Ignore(u => u.ProductsInCart);
        }
    }
}
