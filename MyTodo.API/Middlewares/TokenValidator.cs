
using Microsoft.AspNetCore.Authorization;
using MyTodo.API.Helper;
using Newtonsoft.Json;

namespace MyTodo.API.Middlewares
{
	public class TokenValidator
	{
		private readonly RequestDelegate _next;

		public TokenValidator(RequestDelegate next)
        {
			this._next = next;
		}
        public async Task InvokeAsync(HttpContext context)
		{

			// Check if the endpoint has the AllowAnonymous attribute
			var endpoint = context.GetEndpoint();
			if (endpoint?.Metadata.GetMetadata<AllowAnonymousAttribute>() != null)
			{
				await _next(context); // Bypass token validation
				return;
			}



			if (!context.Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
			{
				var response = new ResponseData() { StatusCode = 401, ErrorMessgae = "Authorization header missing." };
				var jsonResponse = JsonConvert.SerializeObject(response); // Or use System.Text.Json
				context.Response.StatusCode = StatusCodes.Status401Unauthorized;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(jsonResponse);
				return;
			}

			await _next(context);
		}
	}
}
