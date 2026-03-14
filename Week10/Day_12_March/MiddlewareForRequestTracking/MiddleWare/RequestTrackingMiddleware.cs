using System.Diagnostics;
using MiddlewareForRequestTracking.Models;
using MiddlewareForRequestTracking.Services;

namespace MiddlewareForRequestTracking.Middleware
{
    public class RequestTrackingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestLogService _logService;

        public RequestTrackingMiddleware(RequestDelegate next, IRequestLogService logService)
        {
            _next = next;
            _logService = logService;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();

            _logService.AddLog(new RequestLog
            {
                Url = context.Request.Path,
                ExecutionTime = stopwatch.ElapsedMilliseconds,
                TimeStamp = DateTime.Now
            });
        }
    }
}