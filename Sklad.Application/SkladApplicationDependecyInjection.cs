using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Application
{
    public static class SkladApplicationDependecyInjection
    {
        public static IServiceCollection AddApplicationDepencyInjection(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());


            return services;
        }
    }
}
