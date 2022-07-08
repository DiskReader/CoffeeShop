namespace CoffeeShop.Interfaces
{
    public interface ICoffeeShopDbService
    {
        IEnumerable<Coffee> GetCoffeeList();
        Task<Coffee> GetCoffeeById(int id);
        void CreateCoffee(Coffee coffee);
        void ChangeCoffee(int id, Coffee coffee);
        void DeleteCoffee(int id);
    }
}
