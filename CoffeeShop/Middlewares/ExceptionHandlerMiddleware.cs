using System.Net;

namespace CoffeeShop.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception exception)
            {
                await HandleException(httpContext, exception);
            }
        }

        private async Task HandleException(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            await httpContext.Response.WriteAsync(
                $"Bad Request from the custom middleware. Error code {httpContext.Response.StatusCode}\n{exception.Message}");
        }
    }
}
