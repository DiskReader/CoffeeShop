using AutoMapper;
using CoffeeShop.BLL.Models;

namespace CoffeeShop.BLL.Profiles
{
    public class CoffeeProfile : Profile
    {
        public CoffeeProfile()
        {
            CreateMap<Coffee, CoffeeEntity>().ReverseMap();
        }
    }
}
