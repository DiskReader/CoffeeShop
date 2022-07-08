using CoffeeShop.Context;
using CoffeeShop.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Repositories
{
    public class CoffeeShopRepository : ICoffeeShopRepository
    {
        private readonly CoffeeShopContext _db;

        public CoffeeShopRepository(CoffeeShopContext db)
        {
            _db = db;
        }

        public IEnumerable<Coffee> GetCoffeeList()
        {
            return _db.Coffees;
        }

        public async Task<Coffee> GetCoffeeById(int id)
        {
            var coffee = await _db.Coffees.FindAsync(id);

            return coffee;
        }

        public void CreateCoffee(Coffee coffee)
        {
            _db.Coffees.Add(coffee);
            _db.SaveChanges();
        }

        public void ChangeCoffee(int id, Coffee coffee)
        {
            _db.Entry(coffee).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteCoffee(int id)
        {
            Coffee coffee = _db.Coffees.Find(id);

            _db.Coffees.Remove(coffee);
            _db.SaveChanges();
        }
    }
}
