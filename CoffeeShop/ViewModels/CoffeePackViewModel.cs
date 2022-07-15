namespace CoffeeShop.ViewModels
{
    public class CoffeePackViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<CoffeeViewModel> Coffees { get; set; }

        public decimal Price { get; set; }
    }
}
