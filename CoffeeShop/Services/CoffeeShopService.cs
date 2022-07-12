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

        public IEnumerable<CoffeeEntity> GetCoffeeList()
        {
            return _repository.GetCoffeeList();
        }

        public async Task<CoffeeEntity> GetCoffeeByIdAsync(int id)
        {
            var coffee = await _repository.GetCoffeeByIdAsync(id);

            if (coffee == null)
            {
                throw new Exception("Coffee with this id does not exist");
            }

            return coffee;
        }

        public void CreateCoffee(CoffeeEntity coffeeEntity)
        {
            var coffeeList = _repository.GetCoffeeList().ToList();

            if (coffeeList.Any(x => x.Id == coffeeEntity.Id))
            {
                throw new ArgumentException("A coffee with this id already exists", nameof(coffeeEntity));
            }

            CoffeeValidation(coffeeEntity);

            _repository.CreateCoffee(coffeeEntity);
        }

        public void ChangeCoffee(int id, CoffeeEntity coffeeEntity)
        {
            var coffeeList = _repository.GetCoffeeList().ToList();

            if (!coffeeList.Any(x => x.Id == coffeeEntity.Id))
            {
                throw new ArgumentException("Coffee with this id does not exist", nameof(coffeeEntity));
            }

            CoffeeValidation(coffeeEntity);

            if (id == coffeeEntity.Id)
            {
                _repository.ChangeCoffee(id, coffeeEntity);
            }
        }

        public void DeleteCoffee(int id)
        {
            CoffeeEntity coffeeEntity = _repository.GetCoffeeByIdAsync(id).Result;

            if (coffeeEntity != null)
            {
                _repository.DeleteCoffee(id);
            }
        }

        private void CoffeeValidation(CoffeeEntity coffeeEntity)
        {
            if (string.IsNullOrWhiteSpace(coffeeEntity.Name) || coffeeEntity.Name.Length > 30)
            {
                throw new ArgumentException("Entered name is not correct", nameof(coffeeEntity));
            }

            if (coffeeEntity.Price <= 0)
            {
                throw new ArgumentException("Entered price is not correct", nameof(coffeeEntity));
            }
        }
    }
}
