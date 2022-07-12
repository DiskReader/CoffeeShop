using System.Net;
using CoffeeShop.ViewModels;

namespace CoffeeShop.Mappers
{
    public class CoffeeMapper
    {
        public CoffeeViewModel Map(CoffeeEntity coffeeEntity)
        {
            return new CoffeeViewModel()
            {
                Id = coffeeEntity.Id,
                Name = coffeeEntity.Name,
                Price = coffeeEntity.Price
            };
        }

        public CoffeeEntity Map(CoffeeViewModel coffee)
        {
            return new CoffeeEntity()
            {
                Id = coffee.Id,
                Name = coffee.Name,
                Price = coffee.Price
            };
        }

        public IEnumerable<CoffeeViewModel> Map(IEnumerable<CoffeeEntity> coffees)
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
