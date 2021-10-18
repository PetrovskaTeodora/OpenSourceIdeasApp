using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebUI.Middlewares
{
    public class ErrorLoggingMiddleware
    {
        const string MessageTemplate = "HTTP {RequestMethod} {RequestPath} respond {StatusCode}";
        private readonly RequestDelegate _next;
        static readonly ILogger Log = Serilog.Log.ForContext<ErrorLoggingMiddleware>();
        public ErrorLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //Log.Information($"Before Request: {context.Request.Path}. User: {context.User.Identity.Name}");
                Log.Information($"Before Request: {context.Request.Path}");
                await _next(context);
            }
            catch (Exception ex)
            {
                var request = context.Request;
                var result = Log.ForContext("RequestHeader", request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()), destructureObjects:true)
                    .ForContext("RequestHost", request.Host)
                    .ForContext("RequestProtocol", request.Protocol);

                if (request.HasFormContentType)
                {
                    result = result.ForContext("RequestForm", request.Form.ToDictionary(k => k.Key, k => k.Value.ToString()));
                }

                result.Error(ex, MessageTemplate, context.Request.Method, context.Request.Path, 500);

                throw;
            }
        }
    }
}
