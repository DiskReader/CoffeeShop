namespace CoffeeShop.ViewModels
{
    public class CoffeeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<CoffeePackViewModel> CoffeePacks { get; set; }
    }
}
