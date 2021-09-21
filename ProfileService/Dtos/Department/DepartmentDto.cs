using System.Text.Json.Serialization;

namespace ProfileService.Dtos.Department
{
	public class DepartmentDto
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("title")]
		public string? Title { get; set; }
	}
}