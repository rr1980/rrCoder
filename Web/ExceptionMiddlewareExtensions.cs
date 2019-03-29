using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace Web
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();


                    if (contextFeature != null)
                    {
                        var orgError = contextFeature.Error;


                        var statusCode = (int)HttpStatusCode.InternalServerError;
                        if (orgError is LoginError)
                        {
                            statusCode = (int)HttpStatusCode.Forbidden;
                        }

                        context.Response.StatusCode = statusCode;

                        var error = new AppError("Internal Server Error", orgError, statusCode);

                        var errorRespnse = JsonConvert.SerializeObject(error, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                            PreserveReferencesHandling = PreserveReferencesHandling.All,
                        });

                        await context.Response.WriteAsync(errorRespnse);
                    }
                });
            });
        }
    }
}
