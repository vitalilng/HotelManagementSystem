using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Shared;
using HotelManagementSystem.Shared.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace HotelManagementSystem.Server.Extensions
{
    /// <summary>
    /// Error handling
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// It captures exceptions that occur during request processing, sets the appropriate response status code based on the exception type,
        /// logs the error, and sends the error details as JSON in the response.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="loggerManager"></param>
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager loggerManager)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        loggerManager.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                        }.ToString());
                    }
                });
            });
        }
    }
}
