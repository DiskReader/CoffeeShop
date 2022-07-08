using CoffeeShop.Context;
using CoffeeShop.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Services
{
    public class CoffeeShopDbService : ICoffeeShopDbService
    {
        private readonly CoffeeShopContext _db;

        public CoffeeShopDbService(CoffeeShopContext db)
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

            if (coffee == null)
            {
                throw new Exception("Coffee with this id does not exist");
            }

            return coffee;
        }

        public void CreateCoffee(Coffee coffee)
        {
            if (_db.Coffees.Any(x => x.Id == coffee.Id))
            {
                throw new ArgumentException("A coffee with this id already exists", nameof(coffee));
            }

            CoffeeValidation(coffee);

            _db.Coffees.Add(coffee);
            _db.SaveChanges();
        }

        public void ChangeCoffee(int id, Coffee coffee)
        {
            if (!_db.Coffees.Any(x => x.Id == coffee.Id))
            {
                throw new ArgumentException("Coffee with this id does not exist", nameof(coffee));
            }

            CoffeeValidation(coffee);

            if (id == coffee.Id)
            {
                _db.Entry(coffee).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public void DeleteCoffee(int id)
        {
            Coffee coffee = _db.Coffees.Find(id);

            if (coffee != null)
            {
                _db.Coffees.Remove(coffee);
                _db.SaveChanges();
            }
        }

        private void CoffeeValidation(Coffee coffee)
        {
            if (string.IsNullOrWhiteSpace(coffee.Name) || coffee.Name.Length > 30)
            {
                throw new ArgumentException("Entered name is not correct", nameof(coffee));
            }

            if (coffee.Price <= 0)
            {
                throw new ArgumentException("Entered price is not correct", nameof(coffee));
            }
        }
    }
}
