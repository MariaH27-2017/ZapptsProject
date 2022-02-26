using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zappts.Domain.Entities;
using Zappts.Domain.Interfaces;
using Zappts.Infra.Data.Repository;
using Zappts.Service.Services;

namespace Zappts.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IBaseService<Livros>, BaseService<Livros>>();
            services.AddScoped<IBaseRepository<Livros>, BaseRepository<Livros>>();

            return services;
        }
    }
}
