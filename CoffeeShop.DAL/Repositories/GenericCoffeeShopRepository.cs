using CoffeeShop.DAL.Context;
using CoffeeShop.DAL.Entities;
using CoffeeShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DAL.Repositories
{
    public class GenericCoffeeShopRepository<TEntity> : IGenericCoffeeShopRepository<TEntity> where TEntity : Entity
    {
        protected readonly CoffeeShopContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericCoffeeShopRepository(CoffeeShopContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task CreateAsync(TEntity tEntity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(tEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task ChangeAsync(int id, TEntity entity, CancellationToken cancellationToken)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            var tEntity = await _dbSet.FindAsync(id, cancellationToken);
            _dbSet.Remove(tEntity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
