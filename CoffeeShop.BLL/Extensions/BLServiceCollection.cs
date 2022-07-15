using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Models;
using CoffeeShop.BLL.Services;
using CoffeeShop.BLL.Validators;
using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BLServiceCollection{
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<ICoffeeShopService, CoffeeShopService>();
            services.AddScoped<IValidator<Coffee>, CoffeeValidator>();

            return services;
        }
    }
}
