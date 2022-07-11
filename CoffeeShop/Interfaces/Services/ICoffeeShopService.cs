using CoffeeShop.Models;

namespace CoffeeShop.Interfaces.Services
{
    public interface ICoffeeShopService
    {
        IEnumerable<CoffeeModel> GetCoffeeList();
        Task<CoffeeModel> GetCoffeeByIdAsync(int id);
        void CreateCoffee(CoffeeModel coffeeModel);
        void ChangeCoffee(int id, CoffeeModel coffeeModel);
        void DeleteCoffee(int id);
    }
}
