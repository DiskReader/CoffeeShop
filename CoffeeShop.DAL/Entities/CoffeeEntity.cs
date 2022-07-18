namespace CoffeeShop.DAL.Entities;

public class CoffeeEntity : Entity
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public List<CoffeePackEntity> CoffeePacks { get; set; }
}