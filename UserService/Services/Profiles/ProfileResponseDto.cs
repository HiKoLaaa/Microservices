using System.Text.Json.Serialization;

namespace UserService.Services.Profiles
{
	public class ProfileResponseDto
	{
		[JsonPropertyName("department_title")]
		public string DepartmentTitle { get; set; } = null!;
	}
}