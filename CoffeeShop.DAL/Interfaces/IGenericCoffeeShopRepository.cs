namespace CoffeeShop.DAL.Interfaces
{
    internal interface IGenericCoffeeShopRepository<T> where T: IEntity
    {
        Task<IEnumerable<T>> GetAllCoffeeAsync(CancellationToken cancellationToken);
        Task<T> GetCoffeeByIdAsync(int id, CancellationToken cancellationToken);
        Task CreateCoffeeAsync(T entity, CancellationToken cancellationToken);
        Task ChangeCoffeeAsync(int id, T entity, CancellationToken cancellationToken);
        Task DeleteCoffeeByIdAsync(int id, CancellationToken cancellationToken);
    }
}
