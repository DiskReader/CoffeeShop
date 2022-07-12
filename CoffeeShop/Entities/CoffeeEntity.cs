using System.ComponentModel.DataAnnotations;

public class CoffeeEntity
{
    [Key]
    public int Id { get; set; }

	public string Name { get; set; }

	public decimal Price { get; set; }
}
