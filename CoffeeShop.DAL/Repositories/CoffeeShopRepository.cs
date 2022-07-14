using CoffeeShop.DAL.Context;
using CoffeeShop.DAL.Entities;
using CoffeeShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DAL.Repositories
{
    public class CoffeeShopRepository : ICoffeeShopRepository
    {
        private readonly CoffeeShopContext _db;

        public CoffeeShopRepository(CoffeeShopContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CoffeeEntity>> GetAllCoffeeAsync(CancellationToken cancellationToken)
        {
            return await _db.Coffees.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<CoffeeEntity> GetCoffeeByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _db.Coffees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task CreateCoffeeAsync(CoffeeEntity coffeeEntity, CancellationToken cancellationToken)
        {
            await _db.Coffees.AddAsync(coffeeEntity, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task ChangeCoffeeAsync(int id, CoffeeEntity coffeeEntity, CancellationToken cancellationToken)
        {
            _db.Entry(coffeeEntity).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCoffeeByIdAsync(int id, CancellationToken cancellationToken)
        {
            var coffeeEntity = await _db.Coffees.FindAsync(id, cancellationToken);
            _db.Coffees.Remove(coffeeEntity);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
