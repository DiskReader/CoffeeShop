using AutoMapper;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Models;
using CoffeeShop.DAL.Entities;
using CoffeeShop.DAL.Interfaces;

namespace CoffeeShop.BLL.Services
{
    public class CoffeeShopService : ICoffeeShopService
    {
        private readonly ICoffeeShopRepository _repository;
        private readonly IMapper _mapper;

        public CoffeeShopService(ICoffeeShopRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<Coffee> GetCoffeeList()
        {
            var coffeeEntities = _repository.GetCoffeeList();
            return _mapper.Map<IEnumerable<Coffee>>(coffeeEntities);
        }

        public async Task<Coffee> GetCoffeeByIdAsync(int id)
        {
            var coffeeEntity = await _repository.GetCoffeeByIdAsync(id);

            if (coffeeEntity == null)
            {
                throw new Exception("Coffee with this id does not exist");
            }

            return _mapper.Map<Coffee>(coffeeEntity);
        }

        public void CreateCoffee(Coffee coffee)
        {
            var coffeeList = _repository.GetCoffeeList().ToList();

            if (coffeeList.Any(x => x.Id == coffee.Id))
            {
                throw new ArgumentException("A coffee with this id already exists", nameof(coffee));
            }

            CoffeeValidation(coffee);
            var coffeeEntity = _mapper.Map<CoffeeEntity>(coffee);
            _repository.CreateCoffee(coffeeEntity);
        }

        public void ChangeCoffee(int id, Coffee coffee)
        {
            var coffeeList = _repository.GetCoffeeList().ToList();

            if (!coffeeList.Any(x => x.Id == coffee.Id))
            {
                throw new ArgumentException("Coffee with this id does not exist", nameof(coffee));
            }

            CoffeeValidation(coffee);
            var coffeeEntity = _mapper.Map<CoffeeEntity>(coffee);

            if (id == coffee.Id)
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
