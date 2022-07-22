using AutoMapper;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Models;
using CoffeeShop.DAL.Entities;
using CoffeeShop.DAL.Interfaces;

namespace CoffeeShop.BLL.Services
{
    public class CoffeeService : GenericCoffeeShopService<Coffee, CoffeeEntity>, ICoffeeService
    {
        public CoffeeService(IGenericCoffeeShopRepository<CoffeeEntity> repository, IMapper mapper)
            : base(repository, mapper)
        { }
    }
}
