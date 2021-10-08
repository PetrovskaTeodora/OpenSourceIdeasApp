using Application.Services;
using Application.Services.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configurations
{
  public static class DIModule
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IIdeaRepository, IdeaRepository>();

            return services;
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IIdeaService, IdeaService>();

            return services;
        }
        public static IServiceCollection RegisterContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OpenSourceIdeasDbContext>(options =>
               options.UseSqlServer(connectionString));


            return services;
        }
    }
}
