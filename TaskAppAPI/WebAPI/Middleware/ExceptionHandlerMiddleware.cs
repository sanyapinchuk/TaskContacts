using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPI.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
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
                await HadleProgramExceptionAsync(context, ex);
            }
        }

        private Task HadleProgramExceptionAsync(HttpContext context, Exception ex)
        {
            var code = context.Response.StatusCode;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            
            var result = JsonSerializer.Serialize(new { code = code, message = ex.Message });
            

            return context.Response.WriteAsync(result);
        }
    }
}
