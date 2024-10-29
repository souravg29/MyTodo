using Newtonsoft.Json;

namespace MyTodo.API.Helper
{
	public class ResponseData
	{
		public int StatusCode { get; set; }

		// Ignore this field if it's null
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string ErrorMessgae { get; set; }
		public object Data { get; set; }
	}
}
