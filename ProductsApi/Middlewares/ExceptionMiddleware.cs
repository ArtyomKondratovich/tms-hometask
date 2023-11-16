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
            catch (Exception exception) 
            {
                context.Response.ContentType = "application/json";

                var response = new CustomException(nameof(exception), exception.Message, (int)HttpStatusCode.InternalServerError);

                context.Response.StatusCode = response.StatusCode;

                var json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
