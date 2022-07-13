using AutoMapper;
using CoffeeShop.BLL.Models;
using CoffeeShop.DAL.Entities;

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
