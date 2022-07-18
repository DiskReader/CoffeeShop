using CoffeeShop.DAL.Context;
using CoffeeShop.DAL.Entities;
using CoffeeShop.DAL.Interfaces;

namespace CoffeeShop.DAL.Repositories
{
    public class CoffeeRepository : GenericCoffeeShopRepository<CoffeeEntity>, ICoffeeRepository
    {
        public CoffeeRepository(CoffeeShopContext context)
        : base(context)
        { }
    }
}
