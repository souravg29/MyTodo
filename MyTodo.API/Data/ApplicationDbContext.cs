using Microsoft.EntityFrameworkCore;
using MyTodo.API.Model;

namespace MyTodo.API.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Todo> Todos { get; set; }
	}
}
