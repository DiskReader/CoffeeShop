using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BLServiceCollection{
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<ICoffeeService, CoffeeService>();
            services.AddScoped<ICoffeePackService, CoffeePackService>();

            return services;
        }
    }
}
