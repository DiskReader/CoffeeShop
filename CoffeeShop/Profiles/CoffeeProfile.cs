using AutoMapper;
using CoffeeShop.Models;
using CoffeeShop.ViewModels;

namespace CoffeeShop.Profiles
{
    public class CoffeeProfile : Profile
    {
        public CoffeeProfile()
        {
            CreateMap<CoffeeViewModel, Coffee>().ReverseMap();
            CreateMap<Coffee, CoffeeEntity>().ReverseMap();
        }
    }
}