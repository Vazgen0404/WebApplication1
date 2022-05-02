using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebApplication1.Middlewares
{
    public class ExceptionMiddlware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddlware> _logger;

        public ExceptionMiddlware(RequestDelegate next, ILogger<ExceptionMiddlware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
