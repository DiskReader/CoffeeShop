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

        public IEnumerable<CoffeeEntity> GetCoffeeList()
        {
            return _db.Coffees;
        }

        public async Task<CoffeeEntity> GetCoffeeByIdAsync(int id)
        {
            var coffeeEntity = await _db.Coffees.FindAsync(id);

            return coffeeEntity;
        }

        public void CreateCoffee(CoffeeEntity coffeeEntity)
        {
            _db.Coffees.Add(coffeeEntity);
            _db.SaveChanges();
        }

        public void ChangeCoffee(int id, CoffeeEntity coffeeEntity)
        {
            _db.Entry(coffeeEntity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteCoffee(int id)
        {
            CoffeeEntity coffeeEntity = _db.Coffees.Find(id);

            _db.Coffees.Remove(coffeeEntity);
            _db.SaveChanges();
        }
    }
}
