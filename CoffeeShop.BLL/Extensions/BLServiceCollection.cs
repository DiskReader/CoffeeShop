using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BLServiceCollection{
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<ICoffeeShopService, CoffeeShopService>();

            return services;
        }
    }
}
