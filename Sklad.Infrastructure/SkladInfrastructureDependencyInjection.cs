using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sklad.Application.Abstraction;
using Sklad.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Infrastructure
{
    public static class SkladInfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureDepencyInjection(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ISkladDbContext, SkladDbContext>(option =>
            {
                option.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
