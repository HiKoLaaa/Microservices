using System.Text.Json.Serialization;

namespace UserService.Dtos
{
	public class UserDto
	{
		[JsonPropertyName("name")]
		public string? AccountName { get; set; }

		[JsonPropertyName("email")]
		public string? AccountEmail { get; set; }

		[JsonPropertyName("account_id")]
		public int AccountId { get; set; }

		[JsonPropertyName("first_name")]
		public string? ProfileFirstName { get; set; }
		
		[JsonPropertyName("last_name")]
		public string? ProfileLastName { get; set; }
		
		[JsonPropertyName("department_title")]
		public string? ProfileDepartmentTitle { get; set; }
	}
}