using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Context
{
    public partial class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext()
        {
        }

        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<CoffeeEntity> Coffees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoffeeEntity>(entity =>
            {
                entity.ToTable("Coffee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
