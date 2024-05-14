using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Exceptions
{
    public class GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        }
        private void HandleException(HttpContext context, Exception exception)
        {
            logger.LogError(exception, exception.Message);
            context.Response.StatusCode = exception switch
            {
                BaseException e => (int)e.StatusCode,
                _ => StatusCodes.Status500InternalServerError,
            };

            var problemDetails = new ProblemDetails
            {
                Status = context.Response.StatusCode,
                Title = "An internal server error occurred.",
                Detail = exception.Message,
            };

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var json = JsonSerializer.Serialize(problemDetails, jsonOptions);

            context.Response.Clear();
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = problemDetails.Status.Value;
            context.Response.WriteAsync(json);
        }
    }
}
