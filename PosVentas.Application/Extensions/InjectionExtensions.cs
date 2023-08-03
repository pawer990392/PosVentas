using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PosVentas.Application.Interfaces;
using PosVentas.Application.Services;
using System.Reflection;

namespace PosVentas.Application.Extensions
{
    public static class InjectionExtensions
    {

        public static IServiceCollection AddInjeccionApplication(this IServiceCollection services,IConfiguration configuration) {


            services.AddSingleton(configuration);

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p =>!p.IsDynamic));
            });
        
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICategoryApplication,CategoryApplication>();

            return services;
        }

        

    }
}
