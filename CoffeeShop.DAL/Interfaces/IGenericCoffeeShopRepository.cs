namespace CoffeeShop.DAL.Interfaces
{
    public interface IGenericCoffeeShopRepository<T> where T: IEntity
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task CreateAsync(T tEntity, CancellationToken cancellationToken);
        Task ChangeAsync(int id, T entity, CancellationToken cancellationToken);
        Task DeleteByIdAsync(int id, CancellationToken cancellationToken);
    }
}
