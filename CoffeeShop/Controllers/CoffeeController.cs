using AutoMapper;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Models;
using CoffeeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : Controller
    {
        private readonly ICoffeeService _service;
        private readonly IMapper _mapper;

        public CoffeeController(ICoffeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CoffeeViewModel>> GetAllCoffeeAsync(CancellationToken cancellationToken)
        {
            var coffees = await _service.GetAllCoffeeAsync(cancellationToken);

            return _mapper.Map<IEnumerable<CoffeeViewModel>>(coffees);
        }

        [HttpGet("{id}")]
        public async Task<CoffeeViewModel> GetCoffeeByIdAsync(int id, CancellationToken cancellationToken)
        {
            var coffee = await _service.GetCoffeeByIdAsync(id, cancellationToken);

            return _mapper.Map<CoffeeViewModel>(coffee);
        }

        [HttpPost]
        public async Task CreateCoffeeAsync([FromBody] CoffeeViewModel coffeeViewModel, CancellationToken cancellationToken)
        {
            var coffee = _mapper.Map<Coffee>(coffeeViewModel);
            await _service.CreateCoffeeAsync(coffee, cancellationToken);
        }

        [HttpPut]
        public async Task ChangeCoffeeAsync(int id, [FromBody] CoffeeViewModel coffeeViewModel, CancellationToken cancellationToken)
        {
            var coffee = _mapper.Map<Coffee>(coffeeViewModel);
            await _service.ChangeCoffeeAsync(id, coffee, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCoffeeByIdAsync(int id, CancellationToken cancellationToken)
        {
            await _service.DeleteCoffeeByIdAsync(id, cancellationToken);
        }
    }
}