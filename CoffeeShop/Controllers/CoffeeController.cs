using CoffeeShop.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : Controller
    {
        private readonly ILogger<CoffeeController> _logger;

        private CoffeeShopContext db = new CoffeeShopContext();

        public CoffeeController(ILogger<CoffeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Coffee> GetCoffeeList()
        {
            return db.Coffees;
        }

        [HttpGet("{id}")]
        public async Task<Coffee> GetCoffeeById(int id)
        {
            var coffee = await db.Coffees.FindAsync(id);

            if (coffee == null)
            {
                throw new Exception("Coffee with this id does not exist");
            }

            return coffee;
        }

        [HttpPost]
        public void CreateCoffee([FromBody]Coffee coffee)
        {
            if (db.Coffees.Any(x => x.Id == coffee.Id))
            {
                throw new ArgumentException("A coffee with this id already exists", nameof(coffee));
            }

            CoffeeValidation(coffee);

            db.Coffees.Add(coffee);
            db.SaveChanges();
        }

        [HttpPut]
        public void ChangeCoffee(int id, [FromBody]Coffee coffee)
        {
            if (!db.Coffees.Any(x => x.Id == coffee.Id))
            {
                throw new ArgumentException("Coffee with this id does not exist", nameof(coffee));
            }

            CoffeeValidation(coffee);

            if (id == coffee.Id)
            {
                db.Entry(coffee).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteCoffee(int id)
        {
            Coffee coffee = db.Coffees.Find(id);

            if (coffee != null)
            {
                db.Coffees.Remove(coffee);
                db.SaveChanges();
            }
        }

        private void CoffeeValidation(Coffee coffee)
        {
            if (string.IsNullOrWhiteSpace(coffee.Name) || coffee.Name.Length > 30)
            {
                throw new ArgumentException("Entered name is not correct", nameof(coffee));
            }

            if (coffee.Price <= 0)
            {
                throw new ArgumentException("Entered price is not correct", nameof(coffee));
            }
        }
    }
}