using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MyTodo.API.Model
{
	public class Todo
	{
		[Key]
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string? ShortDescription { get; set; }
		public string? LongDescription { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
	}
}
