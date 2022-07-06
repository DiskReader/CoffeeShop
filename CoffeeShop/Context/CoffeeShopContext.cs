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

        public virtual DbSet<Coffee> Coffees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MA-BOII;Database=CoffeeShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coffee>(entity =>
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
