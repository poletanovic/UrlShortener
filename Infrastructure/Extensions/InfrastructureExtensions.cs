using Application.Common.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Jwt;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    { 
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "NewsyImDb")
            );

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddJwtAuthentication(config);

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IUserManager, IdentityService>();

            return services;
        }
    }
}
