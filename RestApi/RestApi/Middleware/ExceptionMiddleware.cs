using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RestApi.Middleware
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
            catch (Exception ex)
            {
                //錯誤發生會走這邊
                await HandleExcetion(context, ex);
            }
        }

        private static Task HandleExcetion(HttpContext context, Exception ex)
        {
            string ReturnValue;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var json = @"{ ""Message"": ""Internal Server Error"" }";
            ReturnValue = json;

            return context.Response.WriteAsync(ReturnValue);
        }
    }
}
