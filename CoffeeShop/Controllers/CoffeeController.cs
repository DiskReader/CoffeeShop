using AutoMapper;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Models;
using CoffeeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : GenericCoffeeShopController<CoffeeViewModel, Coffee>
    {
        public CoffeeController(IGenericCoffeeShopService<Coffee> service, IMapper mapper)
        :base(service, mapper)
        { }
    }
}