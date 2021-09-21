using System.Text.Json.Serialization;

namespace AccountService.Dtos.Accounts
{
	public class AccountDto
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }
		
		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("email")]
		public string? Email { get; set; }
	}
}