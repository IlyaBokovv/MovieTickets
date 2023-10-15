using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace MovieLibraryWeb.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");

                // You can customize how you want to handle the exception, e.g., return a JSON response.
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                // Create a response object with an error message.
                var response = new { message = "An error occurred." };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
