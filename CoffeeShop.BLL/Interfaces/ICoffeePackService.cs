using CoffeeShop.BLL.Models;

namespace CoffeeShop.BLL.Interfaces
{
    public interface ICoffeePackService : IGenericCoffeeShopService<CoffeePack>
    {
        Task AddCoffeeByIdAsync(CoffeePack coffeePack, int coffeeId, CancellationToken cancellationToken);
        Task DeleteCoffeeByIdAsync(CoffeePack coffeePack, int coffeeId, CancellationToken cancellationToken);
    }
}
