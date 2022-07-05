using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "Arabica", "Robusta", "Decaf", "Espresso", "Latte", "Cappuccino", "Macchiato", "Americano"
        };

        private readonly ILogger<CoffeeController> _logger;

        public CoffeeController(ILogger<CoffeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCoffee")]
        public IEnumerable<Coffee> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Coffee
                {
                    Price = Random.Shared.Next(5, 20),
                    Name = Names[Random.Shared.Next(Names.Length)]
                })
                .ToArray();
        }
    }
}