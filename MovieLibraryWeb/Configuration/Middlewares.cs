using MovieLibraryWeb.Middlewares;
using mvc.Data.DataSeed;

namespace MovieLibraryWeb.Configuration
{
    public static class Middlewares
    {
        public static WebApplication GlobalExceptionHandling(this WebApplication app)
        {
            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();
            return app;
        }
    }
}
