using CoffeeShop.DAL.Context;
using CoffeeShop.DAL.Entities;
using CoffeeShop.DAL.Interfaces;

namespace CoffeeShop.DAL.Repositories
{
    public class CoffeePackRepository : GenericCoffeeShopRepository<CoffeePackEntity>, ICoffeePackRepository
    {
        public CoffeePackRepository(CoffeeShopContext context)
            : base(context)
        { }

        public async Task AddCoffeeByIdAsync(CoffeePackEntity coffeePackEntity, int coffeeId, CancellationToken cancellationToken)
        {
            var coffeeEntity = await new CoffeeRepository(_context).GetByIdAsync(coffeeId, cancellationToken);
            coffeePackEntity.Coffees.Add(coffeeEntity);
            await ChangeAsync(coffeePackEntity.Id, coffeePackEntity, cancellationToken);
        }

        public async Task DeleteCoffeeByIdAsync(CoffeePackEntity coffeePackEntity, int coffeeId, CancellationToken cancellationToken)
        {
            var coffeeEntity = await new CoffeeRepository(_context).GetByIdAsync(coffeeId, cancellationToken);
            coffeePackEntity.Coffees.Remove(coffeeEntity);
            await ChangeAsync(coffeePackEntity.Id, coffeePackEntity, cancellationToken);
        }
    }
}
