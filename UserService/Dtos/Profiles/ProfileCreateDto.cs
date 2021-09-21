using System.Text.Json.Serialization;

namespace UserService.Dtos
{
	public class ProfileCreateDto
	{
		[JsonPropertyName("account_id")]
		public int AccountId { get; set; }

		[JsonPropertyName("first_name")]
		public string? FirstName { get; set; }
		
		[JsonPropertyName("last_name")]
		public string? LastName { get; set; }
		
		[JsonPropertyName("department_id")]
		public int DepartmentId { get; set; }
	}
}