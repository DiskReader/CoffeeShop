using AutoMapper;
using CoffeeShop.Interfaces.Services;
using CoffeeShop.Mappers;
using CoffeeShop.Models;
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
            var coffeeModels = _service.GetCoffeeList();

            return _mapper.Map<IEnumerable<CoffeeViewModel>>(coffeeModels);
        }

        [HttpGet("{id}")]
        public async Task<CoffeeViewModel> GetCoffeeByIdAsync(int id)
        {
            var coffeeModels = await _service.GetCoffeeByIdAsync(id);

            return _mapper.Map<CoffeeViewModel>(coffeeModels);
        }

        [HttpPost]
        public void CreateCoffee([FromBody]CoffeeViewModel coffeeViewModel)
        {
            var coffeeModel = new CoffeeModel();
            _mapper.Map(coffeeViewModel, coffeeModel);
            _service.CreateCoffee(coffeeModel);
        }

        [HttpPut]
        public void ChangeCoffee(int id, [FromBody]CoffeeViewModel coffeeViewModel)
        {
            var coffeeModel = new CoffeeModel();
            _mapper.Map(coffeeViewModel, coffeeModel);
            _service.ChangeCoffee(id, coffeeModel);
        }

        [HttpDelete]
        public void DeleteCoffee(int id)
        {
            _service.DeleteCoffee(id);
        }
    }
}