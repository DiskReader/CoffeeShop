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
            if (db.Coffees.Any(x => x.Id == coffee.Id))
            {
                throw new ArgumentException("A coffee with this id already exists", nameof(coffee));
            }

            if (!IsCoffeeValid(coffee))
            {
                throw new ArgumentException("Entered data is not correct", nameof(coffee));
            }

            db.Coffees.Add(coffee);
            db.SaveChanges();
        }

        [HttpPut]
        public void PutById(int id, [FromBody]Coffee coffee)
        {
            if (!db.Coffees.Any(x => x.Id == coffee.Id))
            {
                throw new ArgumentException("Coffee with this id does not exist", nameof(coffee));
            }

            if (!IsCoffeeValid(coffee))
            {
                throw new ArgumentException("Entered data is not correct", nameof(coffee));
            }

            if (id == coffee.Id)
            {
                db.Entry(coffee).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteById(int id)
        {
            if (!db.Coffees.Any(x => x.Id == id))
            {
                throw new ArgumentException("Coffee with this id does not exist", nameof(id));
            }

            Coffee coffee = db.Coffees.Find(id);

            if (coffee != null)
            {
                db.Coffees.Remove(coffee);
                db.SaveChanges();
            }
        }

        private bool IsCoffeeValid(Coffee coffee)
        {
            if (string.IsNullOrWhiteSpace(coffee.Name) || coffee.Name.Length > 30)
            {
                return false;
            }

            if (coffee.Price <= 0)
            {
                return false;
            }

            return true;
        }
    }
}