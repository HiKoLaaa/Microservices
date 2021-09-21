using System.Text.Json.Serialization;

namespace UserService.Dtos
{
	public class AccountCreateDto
	{
		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("email")]
		public string? Email { get; set; }
	}
}