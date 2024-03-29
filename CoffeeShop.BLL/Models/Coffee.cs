﻿namespace CoffeeShop.BLL.Models
{
    public class Coffee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<CoffeePack> CoffeePacks { get; set; }
    }
}
