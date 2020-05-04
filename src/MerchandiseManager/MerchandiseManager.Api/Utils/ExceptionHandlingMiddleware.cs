using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Utils
{
    public class ExceptionHandlingMiddleware
	{
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            var request = context.Request;
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (exception is ArgumentException) code = HttpStatusCode.BadRequest;

            context.Response.ContentType = "text";
            context.Response.StatusCode = (int)code;

            if (code == HttpStatusCode.InternalServerError && !(exception is Exception))
                return context.Response.WriteAsync("Internal Server Error");

            return context.Response.WriteAsync(exception.Message);
        }
    }
}
