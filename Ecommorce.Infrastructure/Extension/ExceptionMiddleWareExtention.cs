using Ecommorce.Application.ILogger;
using Ecommorce.Model.ErrorModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Infrastructure.Extension
{
    public static class ExceptionMiddleWareExtention
    {
     

        public static readonly ILoggerManger logger;

        public static void ConfigureExceptionHandler(this IApplicationBuilder middleware)
        {
            middleware.UseExceptionHandler(appError => 
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType="application/json";

                    var contextFeature=context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong :{contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode=context.Response.StatusCode,
                            Message="Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}
