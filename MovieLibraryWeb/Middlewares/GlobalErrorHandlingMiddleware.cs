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
                _logger.LogError($"{ex.Message}, {ex.Id}");
                context.Response.StatusCode = ex.StatusCode;
            }
            catch (NotFoundException ex)
            {
                _logger.LogError($"{ex.Message}, {ex.Id}");
                context.Response.StatusCode = ex.StatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Something really bad happen");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
