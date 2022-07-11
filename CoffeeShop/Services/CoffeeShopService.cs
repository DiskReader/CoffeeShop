using AutoMapper;
using CoffeeShop.Interfaces.Repositories;
using CoffeeShop.Interfaces.Services;
using CoffeeShop.Models;

namespace CoffeeShop.Services
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

        public IEnumerable<CoffeeModel> GetCoffeeList()
        {
            var coffees = _repository.GetCoffeeList();
            return _mapper.Map<IEnumerable<CoffeeModel>>(coffees);
        }

        public async Task<CoffeeModel> GetCoffeeByIdAsync(int id)
        {
            var coffee = await _repository.GetCoffeeByIdAsync(id);

            if (coffee == null)
            {
                throw new Exception("Coffee with this id does not exist");
            }

            var coffeeModel = new CoffeeModel();
            _mapper.Map(coffee, coffeeModel);

            return coffeeModel;
        }

        public void CreateCoffee(CoffeeModel coffeeModel)
        {
            var coffeeList = _repository.GetCoffeeList().ToList();

            if (coffeeList.Any(x => x.Id == coffeeModel.Id))
            {
                throw new ArgumentException("A coffee with this id already exists", nameof(coffeeModel));
            }

            CoffeeValidation(coffeeModel);
            var coffee = new Coffee();
            _mapper.Map(coffeeModel, coffee);
            _repository.CreateCoffee(coffee);
        }

        public void ChangeCoffee(int id, CoffeeModel coffeeModel)
        {
            var coffeeList = _repository.GetCoffeeList().ToList();

            if (!coffeeList.Any(x => x.Id == coffeeModel.Id))
            {
                throw new ArgumentException("Coffee with this id does not exist", nameof(coffeeModel));
            }

            CoffeeValidation(coffeeModel);
            var coffee = new Coffee();
            _mapper.Map(coffeeModel, coffee);

            if (id == coffeeModel.Id)
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

        private void CoffeeValidation(CoffeeModel coffeeModel)
        {
            if (string.IsNullOrWhiteSpace(coffeeModel.Name) || coffeeModel.Name.Length > 30)
            {
                throw new ArgumentException("Entered name is not correct", nameof(coffeeModel));
            }

            if (coffeeModel.Price <= 0)
            {
                throw new ArgumentException("Entered price is not correct", nameof(coffeeModel));
            }
        }
    }
}
