using CoffeeShop.BLL.Models;

namespace CoffeeShop.BLL.Interfaces
{
    public interface ICoffeeShopService
    {
        IEnumerable<Coffee> GetCoffeeList();
        Task<Coffee> GetCoffeeByIdAsync(int id);
        void CreateCoffee(Coffee coffee);
        void ChangeCoffee(int id, Coffee coffee);
        void DeleteCoffee(int id);
    }
}
