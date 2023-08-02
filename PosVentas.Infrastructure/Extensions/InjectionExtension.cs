using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//lalamaos al context
using PosVentas.Infrastructure.Persistences.Contexts;
using PosVentas.Infrastructure.Persistences.Interfaces;
using PosVentas.Infrastructure.Persistences.Repositories;

namespace PosVentas.Infrastructure.Extensions
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionInfractructure(this IServiceCollection services,IConfiguration configuration)
        {
            var assembly = typeof(PosContext).Assembly.FullName;

            services.AddDbContext<PosContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("POSConnection"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient
                    );

            services.AddTransient<IUnitOfWork, UnitOfWork>();


            return services;

        }
    }
}
