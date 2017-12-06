using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace OrtWorkshopBackend
{
    public class OrtWorkshopException : Exception
    {
        private readonly HttpStatusCode httpStatusCode;

        public OrtWorkshopException(HttpStatusCode httpStatusCode)
            : base()
        {
            this.httpStatusCode = httpStatusCode;
        }

        public OrtWorkshopException(HttpStatusCode httpStatusCode, string message)
            : base(message)
        {
            this.httpStatusCode = httpStatusCode;
        }

        public HttpStatusCode StatusCode { get => this.httpStatusCode; }
    }

    public class ErrorCustomHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorCustomHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await CustomHandleExceptionAsync(context, ex);
            }
        }

        private static Task CustomHandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            if (exception is OrtWorkshopException)
            {
                code = ((OrtWorkshopException)exception).StatusCode;
            }

            var result = JsonConvert.SerializeObject(new { error = exception.Message });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }

    public static class ErrorCustomHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorCustomHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorCustomHandlingMiddleware>();
        }
    }
}