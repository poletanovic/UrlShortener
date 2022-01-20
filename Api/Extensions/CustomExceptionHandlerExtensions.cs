using Api.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extensions
{
    public static class CustomExceptionHandlerExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }

        //public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        //{
        //    app.UseExceptionHandler(error => {
        //        error.Run(async context => {
        //            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        //            context.Response.ContentType = "application/json";
        //            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        //            if (contextFeature != null)
        //            {
        //                //Log.Error($"Something Went Wrong in the {contextFeature.Error}");

        //                await context.Response.WriteAsync(new
        //                {
        //                    StatusCode = context.Response.StatusCode,
        //                    Message = "Internal Server Error. Please Try Again Later."
        //                }.ToString());
        //            }
        //        });
        //    });
        //}
    }
}
