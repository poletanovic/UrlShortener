using Application.Common.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDataAsync(IUserManager identityService, ApplicationDbContext context)
        {

            var result = await identityService.CreateUserAsync("marko@mail.com", "marko@mail.com", "Pass#1234");

            if (!context.News.Any())
            {
                context.News.AddRange(
                    new News { Title = "News-1", Text = "Text-1", AuthorId = (int)result.RetVal.Item2 },
                    new News { Title = "News-2", Text = "Text-2",  AuthorId = (int)result.RetVal.Item2 },
                    new News { Title = "News-3", Text = "Text-3",  AuthorId = (int)result.RetVal.Item2 }
                );

                await context.SaveChangesAsync(new CancellationToken());
            }

            if (!context.UrlModels.Any())
            {
                context.UrlModels.AddRange(
                    new UrlModel { LongName= "https://github.com/jasontaylordev/CleanArchitecture", ShortName= "sdnahknwadnjjd" }    
                );
            }
        }
        public static async Task UseSeedDataAsync(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                await SeedDataAsync(serviceScope.ServiceProvider.GetService<IUserManager>(), serviceScope.ServiceProvider.GetService<ApplicationDbContext>());
            }

        }
    }

    
}
