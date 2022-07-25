using AutoMapper;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Models;
using CoffeeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CoffeePackController : GenericCoffeeShopController<CoffeePackViewModel, CoffeePack>
    {
        private readonly ICoffeePackService _service;

        public CoffeePackController(ICoffeePackService service, IMapper mapper)
            : base(service, mapper)
        {
            _service = service;
        }

        [HttpPut("{coffeeId}")]
        public async Task AddCoffeeByIdAsync(CoffeePackViewModel coffeePackViewModel, int coffeeId, CancellationToken cancellationToken)
        {
            var coffeePack = _mapper.Map<CoffeePack>(coffeePackViewModel);
            await _service.AddCoffeeByIdAsync(coffeePack, coffeeId, cancellationToken);
        }

        [HttpDelete("{coffeeId}")]
        public async Task DeleteCoffeeByIdAsync(CoffeePackViewModel coffeePackViewModel, int coffeeId, CancellationToken cancellationToken)
        {
            var coffeePack = _mapper.Map<CoffeePack>(coffeePackViewModel);
            await _service.DeleteCoffeeByIdAsync(coffeePack, coffeeId, cancellationToken);
        }
    }
}
