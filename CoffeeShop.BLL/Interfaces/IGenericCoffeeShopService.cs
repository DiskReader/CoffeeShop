namespace CoffeeShop.BLL.Interfaces
{
    public interface IGenericCoffeeShopService<TModel> 
        where TModel : class
    {
        Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<TModel> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task CreateAsync(TModel model, CancellationToken cancellationToken);
        Task ChangeAsync(int id, TModel model, CancellationToken cancellationToken);
        Task DeleteByIdAsync(int id, CancellationToken cancellationToken);
    }
}
