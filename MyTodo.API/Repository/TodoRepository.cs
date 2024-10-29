using Microsoft.EntityFrameworkCore;
using MyTodo.API.Data;
using MyTodo.API.Model;

namespace MyTodo.API.Repository
{
	public class TodoRepository : ITodoRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public TodoRepository(ApplicationDbContext dbContext)
		{
			this._dbContext = dbContext;
		}
		public async Task CreateTodoAsync(Todo todo)
		{
			await _dbContext.Todos.AddAsync(todo);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteTodoAsync(Guid todoId)
		{
			var todo = await _dbContext.Todos.FindAsync(todoId);
			if (todo != null)
			{
				_dbContext.Todos.Remove(todo);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Todo>> GetAllTodoASync()
		{
			return await _dbContext.Todos.ToListAsync();
		}

		public async Task<Todo> GetTodoByIdAsync(Guid todoId)
		{
			return await _dbContext.Todos.FindAsync(todoId);
		}

		public async Task UpdateTodoAsync(Todo todo)
		{
			_dbContext.Todos.Update(todo);
			await _dbContext.SaveChangesAsync();
		}
	}
}
