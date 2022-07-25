using CoffeeShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DAL.Context
{
    public class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext()
        {
        }

        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<CoffeeEntity> Coffees { get; set; }
        public virtual DbSet<CoffeeEntity> CoffeePacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoffeeEntity>(entity =>
            {
                entity.ToTable("Coffee");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<CoffeePackEntity>(entity =>
            {
                entity.ToTable("CoffeePack");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasMany(d => d.Coffees)
                    .WithMany(p => p.CoffeePacks)
                    .UsingEntity<Dictionary<string, object>>(
                        "CoffeeEntityCoffeePackEntity",
                        l => l.HasOne<CoffeeEntity>().WithMany().HasForeignKey("CoffeesId"),
                        r => r.HasOne<CoffeePackEntity>().WithMany().HasForeignKey("CoffeePacksId"),
                        j =>
                        {
                            j.HasKey("CoffeePacksId", "CoffeesId");

                            j.ToTable("CoffeeEntityCoffeePackEntity");

                            j.HasIndex(new[] { "CoffeesId" }, "IX_CoffeeEntityCoffeePackEntity_CoffeesId");
                        });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
