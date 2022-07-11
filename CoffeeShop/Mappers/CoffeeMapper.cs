using System.Net;
using CoffeeShop.ViewModels;

namespace CoffeeShop.Mappers
{
    public class CoffeeMapper
    {
        public CoffeeViewModel Map(Coffee coffee)
        {
            return new CoffeeViewModel()
            {
                Id = coffee.Id,
                Name = coffee.Name,
                Price = coffee.Price
            };
        }

        public Coffee Map(CoffeeViewModel coffee)
        {
            return new Coffee()
            {
                Id = coffee.Id,
                Name = coffee.Name,
                Price = coffee.Price
            };
        }

        public IEnumerable<CoffeeViewModel> Map(IEnumerable<Coffee> coffees)
        {
            var result = new List<CoffeeViewModel>();

            foreach (var coffee in coffees)
            {
                result.Add(Map(coffee));
            }

            return result;
        }
    }
}
