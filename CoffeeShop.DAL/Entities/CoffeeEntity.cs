using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.DAL.Entities;

public class CoffeeEntity
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public List<CoffeePackEntity> CoffeePacks { get; set; }
}