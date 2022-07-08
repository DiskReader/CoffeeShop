namespace CoffeeShop.Interfaces.Repositories
{
    public interface ICoffeeShopRepository
    {
        IEnumerable<Coffee> GetCoffeeList();
        Task<Coffee> GetCoffeeById(int id);
        void CreateCoffee(Coffee coffee);
        void ChangeCoffee(int id, Coffee coffee);
        void DeleteCoffee(int id);
    }
}
