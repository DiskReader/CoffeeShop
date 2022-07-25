using AutoMapper;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Models;
using CoffeeShop.BLL.Services;
using CoffeeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class CoffeePackController : GenericCoffeeShopController<CoffeePackViewModel, CoffeePack>
    {
        private readonly ICoffeePackService _service;

        public CoffeePackController(IGenericCoffeeShopService<CoffeePack> service, IMapper mapper)
            : base(service, mapper)
        {
            _service = (CoffeePackService)service;
        }

        [HttpDelete("{CoffeeId}")]
        public async Task AddCoffeeByIdAsync(CoffeePackViewModel coffeePackViewModel, int coffeeId, CancellationToken cancellationToken)
        {
            var coffeePack = _mapper.Map<CoffeePack>(coffeePackViewModel);
            await _service.AddCoffeeByIdAsync(coffeePack, coffeeId, cancellationToken);
        }

        [HttpDelete("{CoffeeId}")]
        public async Task DeleteCoffeeByIdAsync(CoffeePackViewModel coffeePackViewModel, int coffeeId, CancellationToken cancellationToken)
        {
            var coffeePack = _mapper.Map<CoffeePack>(coffeePackViewModel);
            await _service.DeleteCoffeeByIdAsync(coffeePack, coffeeId, cancellationToken);
        }
    }
}
