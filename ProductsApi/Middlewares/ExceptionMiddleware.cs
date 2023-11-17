using Newtonsoft.Json;
using ProductsApi.Exceptions;
using System.Net;
using System.Text.Json;

namespace ProductsApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next) 
        {
            _next = next;   
        }

        public async Task Invoke(HttpContext context)
        {
            try 
            {
                await _next(context); 
            }
            catch (CustomException exception) 
            {
                context.Response.ContentType = "application/json";

                context.Response.StatusCode = exception.StatusCode;

                var json = JsonConvert.SerializeObject(exception);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
