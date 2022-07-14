using CoffeeShop.BLL.Models;

namespace CoffeeShop.BLL.Interfaces
{
    public interface ICoffeeShopService
    {
        Task<IEnumerable<Coffee>> GetAllCoffeeAsync(CancellationToken cancellationToken);
        Task<Coffee> GetCoffeeByIdAsync(int id, CancellationToken cancellationToken);
        Task CreateCoffeeAsync(Coffee coffee, CancellationToken cancellationToken);
        Task ChangeCoffeeAsync(int id, Coffee coffee, CancellationToken cancellationToken);
        Task DeleteCoffeeByIdAsync(int id, CancellationToken cancellationToken);
    }
}
