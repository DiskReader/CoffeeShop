﻿namespace CoffeeShop.Interfaces.Services
{
    public interface ICoffeeShopService
    {
        IEnumerable<CoffeeEntity> GetCoffeeList();
        Task<CoffeeEntity> GetCoffeeByIdAsync(int id);
        void CreateCoffee(CoffeeEntity coffeeEntity);
        void ChangeCoffee(int id, CoffeeEntity coffeeEntity);
        void DeleteCoffee(int id);
    }
}
