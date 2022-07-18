namespace CoffeeShop.DAL.Entities
{
    public class CoffeePackEntity : Entity
    {
        public string Name { get; set; }

        public List<CoffeeEntity> Coffees { get; set; }

        public decimal Price { get; set; }
    }
}
