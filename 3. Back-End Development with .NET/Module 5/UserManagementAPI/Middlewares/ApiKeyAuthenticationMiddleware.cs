namespace UserManagementAPI.Middleware
{
    /// <summary>
    /// Middleware for API key authentication
    /// </summary>
    public class ApiKeyAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiKeyAuthenticationMiddleware> _logger;
        private const string ApiKeyHeaderName = "X-API-Key";
        private const string ValidApiKey = "user-management-api-key-123";

        public ApiKeyAuthenticationMiddleware(RequestDelegate next, ILogger<ApiKeyAuthenticationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (ShouldSkipAuthentication(context))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
            {
                _logger.LogWarning("API Key missing for request {Path}", context.Request.Path);
                await WriteUnauthorizedResponse(context, "API Key is missing");
                return;
            }

            if (!ValidApiKey.Equals(extractedApiKey))
            {
                _logger.LogWarning("Invalid API Key provided for request {Path}", context.Request.Path);
                await WriteUnauthorizedResponse(context, "Invalid API Key");
                return;
            }

            await _next(context);
        }

        private static bool ShouldSkipAuthentication(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();
            return path?.Contains("/swagger") == true || path?.Contains("/openapi") == true;
        }

        private static async Task WriteUnauthorizedResponse(HttpContext context, string message)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { message });
        }
    }
}