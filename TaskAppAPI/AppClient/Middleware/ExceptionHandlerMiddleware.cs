using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace AppClient.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _enviroment;

        public ExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment environment)
        {
            _next = next;
            _enviroment = environment;
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

            
            var result = JsonSerializer.Serialize(new { code = code, message = ex.Message }, new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic) });

            if (_enviroment.IsDevelopment())
            {
                
                return context.Response.WriteAsync(result);
            }
            else
            {
                context.Response.StatusCode = 500;
                return context.Response.WriteAsync("Server error");
            }
            
        }
    }
}
