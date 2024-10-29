
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MyTodo.API.Data;
using MyTodo.API.Middlewares;
using MyTodo.API.Repository;
using System.Text.Json;

namespace MyTodo.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddTransient<ITodoRepository, TodoRepository>();


			// Register the DbContext with an in-memory database
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseInMemoryDatabase("TodoDB"));



			builder.Services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
			});
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();



			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}


			app.UseMiddleware<LoggingMiddleware>();
			app.UseMiddleware<TokenValidator>();
			app.UseMiddleware<ErrorHandlingMiddleware>();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
