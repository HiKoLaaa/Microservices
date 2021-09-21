using System.Text.Json.Serialization;

namespace UserService.Dtos
{
	public class DepartmentDto
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("title")]
		public string Title { get; set; } = null!;
	}
}