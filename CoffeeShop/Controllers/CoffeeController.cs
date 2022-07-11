using CoffeeShop.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : Controller
    {
        private readonly ICoffeeShopService _service;

        public CoffeeController(ICoffeeShopService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Coffee> GetCoffeeList()
        {
            return _service.GetCoffeeList();
        }

        [HttpGet("{id}")]
        public async Task<Coffee> GetCoffeeByIdAsync(int id)
        {
            var coffee = await _service.GetCoffeeByIdAsync(id);

            return coffee;
        }

        [HttpPost]
        public void CreateCoffee([FromBody]Coffee coffee)
        {
            _service.CreateCoffee(coffee);
        }

        [HttpPut]
        public void ChangeCoffee(int id, [FromBody]Coffee coffee)
        {
            _service.ChangeCoffee(id, coffee);
        }

        [HttpDelete]
        public void DeleteCoffee(int id)
        {
            _service.DeleteCoffee(id);
        }
    }
}