using DataManagement.API.Middlewares;

namespace DataManagement.API.Extensions
{
    public static class WebApplicationExtension
    {
        public static WebApplication AddMiddlewares(this WebApplication application)
        {
            application.UseMiddleware<ExceptionsHandlingMiddleware>();

            return application;
        }
    }
}
