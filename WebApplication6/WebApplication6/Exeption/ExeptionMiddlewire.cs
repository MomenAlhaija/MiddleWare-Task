using Download_API.ViewModel;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

using System.Net;
namespace Download_API.Exeption
{
    public static class ExeptionMiddlewire
    {
        public static void ConfigureBuilderInException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(
                appError =>
                {
                    appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextfeature = context.Features.Get<IExceptionHandlerFeature>();
                    var contextRequest = context.Features.Get<IHttpRequestFeature>();
                    if (contextfeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorVM()
                        {
                            StatusCode=context.Response.StatusCode,
                            Message=contextfeature.Error.Message,
                            Path=contextfeature.Path

                        }.ToString());
                        
                    }

                });

                });
        }
    }
}
