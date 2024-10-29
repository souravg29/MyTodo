using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTodo.API.Helper;
using MyTodo.API.Model;
using MyTodo.API.Repository;

namespace MyTodo.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController : ControllerBase
	{
		private readonly ITodoRepository _todoRepository;

		public TodoController(ITodoRepository todoRepository)
        {
			this._todoRepository = todoRepository;
		}

        [HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			var allTodo = await _todoRepository.GetAllTodoASync();

			var response = new ResponseData()
			{
				StatusCode = 200,
				Data = allTodo
			};

			return Ok(response);
		}

		[HttpGet("todoId")]
		public async Task<IActionResult> GetTodoById(Guid todoId)
		{
			var todo = await _todoRepository.GetTodoByIdAsync(todoId);
			var response = new ResponseData()
			{
				StatusCode = 200,
				Data = todo
			};
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> CreateTodo([FromBody] Todo todo)
		{
			 await _todoRepository.CreateTodoAsync(todo);
			var response = new ResponseData()
			{
				StatusCode = 201,
				Data = todo
			};

			return Ok(response);
		}

		[AllowAnonymous]
		[HttpGet("exception-test")]
		public IActionResult HelloWorld()
		{
			throw new Exception("exception occured!!!");
		}
	}
}
