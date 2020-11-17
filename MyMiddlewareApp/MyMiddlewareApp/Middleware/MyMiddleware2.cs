using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MyMiddlewareApp.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyMiddleware2
    {
        private readonly RequestDelegate _next;

        public MyMiddleware2(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Request.Headers.Add("MyMiddleware2", DateTime.Now.ToString("mm:ss"));
            //httpContext.Response.Headers.Add("MyMiddleware2", DateTime.Now.ToString("mm:ss"));
            //httpContext.Response.StatusCode=404;
         var s=   httpContext.Response.Body;
            Thread.Sleep(1000);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyMiddleware2Extensions
    {
        public static IApplicationBuilder UseMyMiddleware2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware2>();
        }
    }
}
