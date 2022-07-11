using AutoMapper;
using CoffeeShop.Interfaces.Services;
using CoffeeShop.Mappers;
using CoffeeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : Controller
    {
        private readonly ICoffeeShopService _service;
        private readonly IMapper _mapper;

        public CoffeeController(ICoffeeShopService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CoffeeViewModel> GetCoffeeList()
        {
            var coffees = _service.GetCoffeeList();

            return _mapper.Map<IEnumerable<CoffeeViewModel>>(coffees);
        }

        [HttpGet("{id}")]
        public async Task<CoffeeViewModel> GetCoffeeByIdAsync(int id)
        {
            var coffee = await _service.GetCoffeeByIdAsync(id);

            return _mapper.Map<CoffeeViewModel>(coffee);
        }

        [HttpPost]
        public void CreateCoffee([FromBody]CoffeeViewModel coffee)
        {
            var result = _mapper.Map<Coffee>(coffee);
            _service.CreateCoffee(result);
        }

        [HttpPut]
        public void ChangeCoffee(int id, [FromBody]CoffeeViewModel coffee)
        {
            var result = _mapper.Map<Coffee>(coffee);
            _service.ChangeCoffee(id, result);
        }

        [HttpDelete]
        public void DeleteCoffee(int id)
        {
            _service.DeleteCoffee(id);
        }
    }
}