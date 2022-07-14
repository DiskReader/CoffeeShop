using CoffeeShop.DAL.Entities;

namespace CoffeeShop.DAL.Interfaces
{
    public interface ICoffeeShopRepository
    {
        Task<IEnumerable<CoffeeEntity>> GetAllCoffeeAsync(CancellationToken cancellationToken);
        Task<CoffeeEntity> GetCoffeeByIdAsync(int id, CancellationToken cancellationToken);
        Task CreateCoffeeAsync(CoffeeEntity coffeeEntity, CancellationToken cancellationToken);
        Task ChangeCoffeeAsync(int id, CoffeeEntity coffeeEntity, CancellationToken cancellationToken);
        Task DeleteCoffeeByIdAsync(int id, CancellationToken cancellationToken);
    }
}
