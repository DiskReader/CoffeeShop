using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Profiles;
using CoffeeShop.BLL.Services;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BLServiceCollection{
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICoffeeService, CoffeeService>();
            services.AddScoped<ICoffeePackService, CoffeePackService>();
            services.AddAutoMapper(typeof(CoffeeProfile));
            services.AddDataAccess(configuration);

            return services;
        }
    }
}
