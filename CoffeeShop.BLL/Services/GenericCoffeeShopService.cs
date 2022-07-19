using AutoMapper;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.DAL.Interfaces;

namespace CoffeeShop.BLL.Services
{
    public class GenericCoffeeShopService<TModel, TEntity> : IGenericCoffeeShopService<TModel> 
        where TModel : class
        where TEntity : IEntity
    {
        private readonly IGenericCoffeeShopRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GenericCoffeeShopService(IGenericCoffeeShopRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TModel>>(entities);
        }

        public async Task<TModel> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);

            if (entity == null)
            {
                throw new Exception("Id does not exist");
            }

            return _mapper.Map<TModel>(entity);
        }

        public async Task CreateAsync(TModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(model);
            await _repository.CreateAsync(entity, cancellationToken);
        }

        public async Task ChangeAsync(int id, TModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(model);
            await _repository.ChangeAsync(id, entity, cancellationToken);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);

            if (entity != null)
            {
                await _repository.DeleteByIdAsync(id, cancellationToken);
            }
        }
    }
}
