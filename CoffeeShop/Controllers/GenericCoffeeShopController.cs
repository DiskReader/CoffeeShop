using AutoMapper;
using CoffeeShop.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class GenericCoffeeShopController<TViewModel, TModel> : Controller
        where TViewModel : class
        where TModel : class
    {
        private readonly IGenericCoffeeShopService<TModel> _service;
        private readonly IMapper _mapper;

        public GenericCoffeeShopController(IGenericCoffeeShopService<TModel> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TViewModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var tModels = await _service.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TViewModel>>(tModels);
        }

        [HttpGet("{id}")]
        public async Task<TViewModel> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var tModels = await _service.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<TViewModel>(tModels);
        }

        [HttpPost]
        public async Task CreateAsync([FromBody] TViewModel tViewModel, CancellationToken cancellationToken)
        {
            var tModel = _mapper.Map<TModel>(tViewModel);
            await _service.CreateAsync(tModel, cancellationToken);
        }

        [HttpPut]
        public async Task ChangeAsync(int id, [FromBody] TViewModel tViewModel, CancellationToken cancellationToken)
        {
            var tModel = _mapper.Map<TModel>(tViewModel);
            await _service.ChangeAsync(id, tModel, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            await _service.DeleteByIdAsync(id, cancellationToken);
        }
    }
}
