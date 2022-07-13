using CoffeeShop.DAL.Context;
using CoffeeShop.DAL.Interfaces;
using CoffeeShop.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DAServiceCollection 
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CoffeeShopContext>(c => c.UseSqlServer(connection));
            services.AddScoped<ICoffeeShopRepository, CoffeeShopRepository>();

            return services;
        }
    }
}
