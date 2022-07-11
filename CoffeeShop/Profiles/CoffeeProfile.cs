using AutoMapper;
using CoffeeShop.ViewModels;

namespace CoffeeShop.Profiles
{
    public class CoffeeProfile : Profile
    {
        public CoffeeProfile()
        {
            CreateMap<Coffee, CoffeeViewModel>().ReverseMap();
        }
    }
}
