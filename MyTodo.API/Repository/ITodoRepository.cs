using MyTodo.API.Model;

namespace MyTodo.API.Repository
{
	public interface ITodoRepository
	{
		Task<IEnumerable<Todo>> GetAllTodoASync();
		Task<Todo> GetTodoByIdAsync(Guid todoId);
		Task UpdateTodoAsync(Todo todo);
		Task DeleteTodoAsync(Guid todoId);
		Task CreateTodoAsync(Todo todo);
	}
}
