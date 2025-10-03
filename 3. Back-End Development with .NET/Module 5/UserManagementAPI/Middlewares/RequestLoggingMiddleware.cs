namespace UserManagementAPI.Middleware
{
    /// <summary>
    /// Middleware for logging HTTP requests and responses
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var startTime = DateTime.UtcNow;
            
            _logger.LogInformation("Starting {Method} {Path} at {Time}",
                context.Request.Method,
                context.Request.Path,
                startTime);

            try
            {
                await _next(context);
            }
            finally
            {
                var duration = (DateTime.UtcNow - startTime).TotalMilliseconds;
                
                _logger.LogInformation("Completed {Method} {Path} with {StatusCode} in {Duration}ms",
                    context.Request.Method,
                    context.Request.Path,
                    context.Response.StatusCode,
                    duration);
            }
        }
    }
}