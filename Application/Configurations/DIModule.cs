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
        public static IServiceCollection Register(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OpenSourceIdeasDbContext>(options =>
               options.UseSqlServer(connectionString));

            services.AddTransient<IIdeaRepository, IdeaRepository>();

            return services;
        }
    }
}
