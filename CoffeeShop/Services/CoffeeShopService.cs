using CoffeeShop.Interfaces.Repositories;
using CoffeeShop.Interfaces.Services;

namespace CoffeeShop.Services
{
    public class CoffeeShopService : ICoffeeShopService
    {
        private readonly ICoffeeShopRepository _repository;

        public CoffeeShopService(ICoffeeShopRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Coffee> GetCoffeeList()
        {
            return _repository.GetCoffeeList();
        }

        public async Task<Coffee> GetCoffeeByIdAsync(int id)
        {
            var coffee = await _repository.GetCoffeeByIdAsync(id);

            if (coffee == null)
            {
                throw new Exception("Coffee with this id does not exist");
            }

            return coffee;
        }

        public void CreateCoffee(Coffee coffee)
        {
            var coffeeList = _repository.GetCoffeeList().ToList();

            if (coffeeList.Any(x => x.Id == coffee.Id))
            {
                throw new ArgumentException("A coffee with this id already exists", nameof(coffee));
            }

            CoffeeValidation(coffee);

            _repository.CreateCoffee(coffee);
        }

        public void ChangeCoffee(int id, Coffee coffee)
        {
            var coffeeList = _repository.GetCoffeeList().ToList();

            if (!coffeeList.Any(x => x.Id == coffee.Id))
            {
                throw new ArgumentException("Coffee with this id does not exist", nameof(coffee));
            }

            CoffeeValidation(coffee);

            if (id == coffee.Id)
            {
                _repository.ChangeCoffee(id, coffee);
            }
        }

        public void DeleteCoffee(int id)
        {
            Coffee coffee = _repository.GetCoffeeByIdAsync(id).Result;

            if (coffee != null)
            {
                _repository.DeleteCoffee(id);
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
