using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.DAL.Entities
{
    public class CoffeePackEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<CoffeeEntity> Coffees { get; set; }

        public decimal Price { get; set; }
    }
}
