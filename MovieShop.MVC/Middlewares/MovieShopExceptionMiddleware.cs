using ApplicationCore.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using Serilog;
using System.Collections.Generic;

namespace MovieShop.MVC.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionMiddleware> _logger;

        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("Middleware is catching exception");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            // get all the information you want to log and use Serilog or Nlog to log exceptions to text/json files.
            _logger.LogError("Starting Logging for Exception");

            ClaimsPrincipal principal = httpContext.User;

            var claimItems = new List<string>();
            foreach (Claim claim in principal.Claims)
            {
                    claimItems.Add(claim.Value);
            }

            var errorModel = new ErrorResponseModel
            {
                ExceptionMessage = ex.Message, 
                ExceptionStackTrace = ex.StackTrace,
                InnerExceptionMessage = ex.InnerException?.Message,
                // fill up remaining info , email, ...etch found in ErrorResponseModel
                FullName = claimItems[0] + " " + claimItems[1],
                UserId = claimItems[2],
                Email = claimItems[3],
                ExceptionDateTime = DateTime.UtcNow
            };

            switch (ex)
            {
                case ConflictException conflictException:
                    httpContext.Response.StatusCode = (int) HttpStatusCode.Conflict;
                    break;

                case NotFoundException notFoundException:
                    httpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;
                    break;

                case UnauthorizedAccessException unauthorized:
                    httpContext.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                    break;

                case Exception exception:
                    httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    break;
            }

            // Serilog to log errorModel along with exception model.
            // redirect to error page
            // send email as well.
            var message =
                $"Exception Code: {httpContext.Response.StatusCode}, {errorModel.ExceptionMessage}, {errorModel.ExceptionStackTrace},{errorModel.InnerExceptionMessage}, {errorModel.FullName}, {errorModel.ExceptionDateTime.ToLongDateString()}";

            _logger.LogInformation(message);
            _logger.LogCritical(message);

            
            httpContext.Response.Redirect("/Home/Error");
            await Task.CompletedTask;
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
