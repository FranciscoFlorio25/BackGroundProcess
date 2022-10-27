using BackGroundProcess.Application.Data;
using BackGroundProcess.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGroundProcess.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<IProductsContext, ProductsContext>(o =>
            o.UseSqlServer(configuration.GetConnectionString(name: "Default")));

            return service;
        }
    }
}
