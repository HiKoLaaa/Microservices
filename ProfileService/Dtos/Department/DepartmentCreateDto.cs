using System.Text.Json.Serialization;

namespace ProfileService.Dtos.Department
{
	public class DepartmentCreateDto
	{
		[JsonPropertyName("title")]
		public string? Title { get; set; }
	}
}