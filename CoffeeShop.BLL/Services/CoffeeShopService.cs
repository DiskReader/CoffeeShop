using AutoMapper;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Models;
using CoffeeShop.DAL.Entities;
using CoffeeShop.DAL.Interfaces;
using FluentValidation;

namespace CoffeeShop.BLL.Services
{
    public class CoffeeShopService : ICoffeeShopService
    {
        private readonly ICoffeeShopRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<Coffee> _validator;

        public CoffeeShopService(ICoffeeShopRepository repository, IMapper mapper, IValidator<Coffee> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IEnumerable<Coffee>> GetAllCoffeeAsync(CancellationToken cancellationToken)
        {
            var coffeeEntities = await _repository.GetAllCoffeeAsync(cancellationToken);
            return _mapper.Map<IEnumerable<Coffee>>(coffeeEntities);
        }

        public async Task<Coffee> GetCoffeeByIdAsync(int id, CancellationToken cancellationToken)
        {
            var coffeeEntity = await _repository.GetCoffeeByIdAsync(id, cancellationToken);

            if (coffeeEntity == null)
            {
                throw new Exception("Coffee with this id does not exist");
            }

            return _mapper.Map<Coffee>(coffeeEntity);
        }

        public async Task CreateCoffeeAsync(Coffee coffee, CancellationToken cancellationToken)
        {
            var result = await _repository.GetCoffeeByIdAsync(coffee.Id, cancellationToken);

            if (result != null)
            {
                throw new ArgumentException("A coffee with this id already exists", nameof(result));
            }

            _validator.ValidateAndThrow(coffee);
            var coffeeEntity = _mapper.Map<CoffeeEntity>(coffee);
            await _repository.CreateCoffeeAsync(coffeeEntity, cancellationToken);
        }

        public async Task ChangeCoffeeAsync(int id, Coffee coffee, CancellationToken cancellationToken)
        {
            var result = await _repository.GetCoffeeByIdAsync(coffee.Id, cancellationToken);

            if (result == null)
            {
                throw new ArgumentException("Coffee with this id does not exist", nameof(coffee));
            }

            _validator.ValidateAndThrow(coffee);
            var coffeeEntity = _mapper.Map<CoffeeEntity>(coffee);

            if (id == coffee.Id)
            {
                await _repository.ChangeCoffeeAsync(id, coffeeEntity, cancellationToken);
            }
        }

        public async Task DeleteCoffeeByIdAsync(int id, CancellationToken cancellationToken)
        {
            var coffeeEntity = await _repository.GetCoffeeByIdAsync(id, cancellationToken);

            if (coffeeEntity != null)
            {
                await _repository.DeleteCoffeeByIdAsync(id, cancellationToken);
            }
        }
    }
}
