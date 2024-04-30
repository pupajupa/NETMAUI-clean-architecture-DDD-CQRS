using _253504_Antikhovitch.Persistense.Data;
using _253504_Antikhovitch.Persistense.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace _253504_Antikhovitch.Persistense
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services,DbContextOptions options)
        {
            services.AddPersistence().AddSingleton<AppDbContext>(new AppDbContext((DbContextOptions<AppDbContext>)options));
            return services;
        }
    }

}
