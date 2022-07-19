using AutoMapper;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Models;
using CoffeeShop.DAL.Entities;
using CoffeeShop.DAL.Interfaces;
using CoffeeShop.DAL.Repositories;

namespace CoffeeShop.BLL.Services
{
    public class CoffeePackService : GenericCoffeeShopService<CoffeePack, CoffeePackEntity>, ICoffeePackService
    {
        private readonly ICoffeePackRepository _repository;

        public CoffeePackService(IGenericCoffeeShopRepository<CoffeePackEntity> repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = (CoffeePackRepository)repository;
        }

        public async Task AddCoffeeByIdAsync(CoffeePack coffeePack, int coffeeId, CancellationToken cancellationToken)
        {
            var coffeePackEntity = _mapper.Map<CoffeePackEntity>(coffeePack);
            await _repository.AddCoffeeByIdAsync(coffeePackEntity, coffeeId, cancellationToken);
        }

        public async Task DeleteCoffeeByIdAsync(CoffeePack coffeePack, int coffeeId, CancellationToken cancellationToken)
        {
            var coffeePackEntity = _mapper.Map<CoffeePackEntity>(coffeePack);
            await _repository.DeleteCoffeeByIdAsync(coffeePackEntity, coffeeId, cancellationToken);
        }
    }
}
