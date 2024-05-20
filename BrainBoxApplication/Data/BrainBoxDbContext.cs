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

       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }      

    }


}
