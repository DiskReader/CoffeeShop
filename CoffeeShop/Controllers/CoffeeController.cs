using CoffeeShop.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly ILogger<CoffeeController> _logger;

        private CoffeeShopContext db = new CoffeeShopContext();

        public CoffeeController(ILogger<CoffeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCoffee")]
        public IEnumerable<Coffee> Get()
        {
            return db.Coffees;
        }

        [HttpPost]
        public void Post([FromForm]Coffee coffee)
        {
            db.Coffees.Add(coffee);
            db.SaveChanges();
        }

        [HttpPut]
        public void Put(int id, [FromForm] Coffee coffee)
        {
            if (id == coffee.Id)
            {
                db.Entry(coffee).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Coffee coffee = db.Coffees.Find(id);
            if (coffee != null)
            {
                db.Coffees.Remove(coffee);
                db.SaveChanges();
            }
        }
    }
}