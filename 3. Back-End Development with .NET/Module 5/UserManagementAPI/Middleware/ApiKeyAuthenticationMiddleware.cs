namespace UserManagementAPI.Middleware
{
    public class ApiKeyAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiKeyAuthenticationMiddleware> _logger;
        private const string ApiKeyHeaderName = "X-API-Key";
        private const string ValidApiKey = "user-management-api-key-123"; // In production, use configuration

        public ApiKeyAuthenticationMiddleware(RequestDelegate next, ILogger<ApiKeyAuthenticationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Skip authentication for swagger and openapi
            var path = context.Request.Path.Value?.ToLower();
            if (path?.Contains("/swagger") == true || 
                path?.Contains("/openapi") == true)
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
            {
                _logger.LogWarning("API Key missing for request {Path}", context.Request.Path);
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key is missing");
                return;
            }

            if (!ValidApiKey.Equals(extractedApiKey))
            {
                _logger.LogWarning("Invalid API Key provided for request {Path}", context.Request.Path);
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }

            await _next(context);
        }
    }
}