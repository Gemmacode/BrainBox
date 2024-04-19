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

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    foreach (var item in ChangeTracker.Entries<BaseEntity>())
        //    {
        //        switch (item.State)
        //        {
        //            case EntityState.Modified:
        //                item.Entity.UpdatedAt = DateTime.UtcNow;
        //                break;
        //            case EntityState.Deleted:
        //                item.Entity.IsDeleted = true;
        //                break;
        //            case EntityState.Added:
                       
        //                item.Entity.CreatedAt = DateTime.UtcNow;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    return await base.SaveChangesAsync(cancellationToken);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Cart>()
        //        .HasMany(c => c.Products)
        //        .WithOne()               
        //        .IsRequired()
        //        .OnDelete(DeleteBehavior.Cascade);
        //}

    }


}
