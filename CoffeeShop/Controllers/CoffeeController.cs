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
        public IEnumerable<Coffee> GetList()
        {
            return db.Coffees;
        }

        [HttpPost]
        public void PostNewCoffee([FromBody]Coffee coffee)
        {
            db.Coffees.Add(coffee);
            db.SaveChanges();
        }

        [HttpPut]
        public void PutById(int id, [FromBody] Coffee coffee)
        {
            if (id == coffee.Id)
            {
                db.Entry(coffee).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteById(int id)
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