using MovieLibrary.Services.Exceptions;
using Serilog;
using System.Net;
using ILogger = Serilog.ILogger;

namespace MovieLibraryWeb.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next,
            ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BadRequestExeption ex)
            {
                if (context.Request.Path.ToString().Contains("/Error"))
                {
                    _logger.LogError($"{ex.Message}, {ex.Id}");
                }
                context.Response.StatusCode = ex.StatusCode;
            }
            catch (NotFoundException ex)
            {
                if (context.Request.Path.ToString().Contains("/Error"))
                {
                    _logger.LogError($"{ex.Message}, {ex.Id}");
                }
                context.Response.StatusCode = ex.StatusCode;
            }
            catch (Exception ex)
            {
                if (context.Request.Path.ToString().Contains("/Error"))
                {
                    _logger.LogCritical(ex.ToString());
                }
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
