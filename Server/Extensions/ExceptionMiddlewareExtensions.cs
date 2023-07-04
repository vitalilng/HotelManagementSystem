using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Shared;
using HotelManagementSystem.Shared.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace HotelManagementSystem.Server.Extensions
{
    /// <summary>
    /// Static class that contain extension method for WebApplication class
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
            //The UseExceptionHandler middleware is added to the application pipeline. 
            //This middleware is responsible for handling exceptions that occur during the processing of HTTP requests.
            //It takes a callback function (appError) as an argument.
            app.UseExceptionHandler(appError =>
            {
                //Run method is called to handle the exception asynchronously
                //context is the current HTTP request context
                appError.Run(async context =>
                {
                    //response content type is set to "application/json"
                    context.Response.ContentType = "application/json";

                    //IExceptionHandlerFeature is retrieved from the request context features
                    //IExceptionHandlerFeature contains information about the exception that occured during request processing.                    
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    //if not null, indicates that an exception occured, then the exception handling logic is executed
                    if (contextFeature != null)
                    {
                        //this code sets the response status code based on the type of exception
                        //if the exception is of type NotFoundException, the status code is set to 404
                        //otherwise is set to 500 InternalServerError
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        loggerManager.LogError($"Something went wrong: {contextFeature.Error}");

                        //This code writes the error details to the response as JSON
                        //It creates an ErrorDetails object containing the status code and exception message
                        //ErrorDetails object is then serialized to JSON using the ToString()
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
