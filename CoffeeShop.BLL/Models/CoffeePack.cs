namespace CoffeeShop.BLL.Models
{
    public class CoffeePack
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Coffee> Coffees { get; set; }

        public decimal Price { get; set; }
    }
}
