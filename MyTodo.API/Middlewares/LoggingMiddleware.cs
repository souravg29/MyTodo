using System.Diagnostics;

namespace MyTodo.API.Middlewares
{
	public class LoggingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<LoggingMiddleware> _logger;

		public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var stopwatch = Stopwatch.StartNew();

			// Log request details
			_logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");

			await _next(context); // Call the next middleware

			// Log response details
			stopwatch.Stop();
			_logger.LogInformation($"Response: {context.Response.StatusCode} - Duration: {stopwatch.ElapsedMilliseconds} ms");
		}
	}
}
