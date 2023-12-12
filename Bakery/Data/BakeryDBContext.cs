using Bakery.Models;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Data
{
    public partial class BakeryDBContext : DbContext
    {

        public BakeryDBContext(DbContextOptions<BakeryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BakeryProduct> BakeryProducts { get; set; } = null!;
        public virtual DbSet<BreadRecipe> BreadRecipes { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Supply> Supplies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BreadRecipe>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Supply>()
                .Property(s => s.Price)
                .HasColumnType("decimal(18,2)");

           

            base.OnModelCreating(modelBuilder);
        }
    }
}
