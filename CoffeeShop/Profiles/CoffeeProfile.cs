using AutoMapper;
using CoffeeShop.BLL.Models;
using CoffeeShop.ViewModels;

namespace CoffeeShop.Profiles
{
    public class CoffeeProfile : Profile
    {
        public CoffeeProfile()
        {
            CreateMap<CoffeeViewModel, Coffee>().ReverseMap();
            CreateMap<CoffeePackViewModel, CoffeePack>().ReverseMap();
        }
    }
}