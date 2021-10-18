using Application.Services;
using Application.Services.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Repositories;
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
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IIdeaService, IdeaService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

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
