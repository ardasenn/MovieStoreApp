using Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace MovieStoreAPI.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILoggerService loggerService;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            this.next = next;
            this.loggerService = loggerService;
        }

        public async Task InvokeAsync (HttpContext context)
        {
            try
            {
                string msg= "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                loggerService.Write(msg);
                await next(context);
                msg= "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responsed "+context.Response.StatusCode;
                loggerService.Write(msg);
            }
            catch (System.Exception ex)
            {
                await Handle(context,ex);
            }
        }
        public Task Handle(HttpContext context,Exception ex)
        {
            context.Response.ContentType= "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string msg= $"[Error  HTTP " + context.Request.Method + " - " + context.Response.StatusCode + "Error Message " + ex.Message;
            loggerService.Write (msg);
            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);//çeviridk
            return context.Response.WriteAsync(result);
        }
    }
    public static class CustomExceptionMiddlewareExtension
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }       
    }
}
