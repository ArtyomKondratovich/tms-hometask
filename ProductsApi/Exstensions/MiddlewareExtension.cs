using ProductsApi.Middlewares;

namespace ProductsApi.Exstensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
