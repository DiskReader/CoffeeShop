using CoffeeShop.DAL.Entities;

namespace CoffeeShop.DAL.Interfaces
{
    public interface ICoffeePackRepository : IGenericCoffeeShopRepository<CoffeePackEntity>
    {
        Task AddCoffeeByIdAsync(CoffeePackEntity coffeePackEntity, int coffeeId, CancellationToken cancellationToken);
        Task DeleteCoffeeByIdAsync(CoffeePackEntity coffeePackEntity, int coffeeId, CancellationToken cancellationToken);
    }
}
