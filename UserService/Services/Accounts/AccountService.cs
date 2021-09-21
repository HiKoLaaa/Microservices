using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UserService.Dtos;

namespace UserService.Services.Accounts
{
	internal class AccountService : IAccountService
	{
		private const string AccountPath = "api/accounts";
		
		private readonly HttpClient _httpClient;

		public AccountService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> AddAccountAsync(AccountCreateDto createDto)
		{
			var response = await _httpClient.PostAsJsonAsync(AccountPath, createDto);
			response.EnsureSuccessStatusCode();

			return (await response.Content.ReadFromJsonAsync<AccountId>())!.Id;
		}

		public async Task UpdateAccountAsync(AccountDto accountDto)
		{
			var response = await _httpClient.PutAsJsonAsync(AccountPath, accountDto);
			response.EnsureSuccessStatusCode();
		}

		public async Task DeleteAccountAsync(int accountId)
		{
			var response = await _httpClient.DeleteAsync($"{AccountPath}/{accountId}");
			response.EnsureSuccessStatusCode();
		}

		private class AccountId
		{
			[JsonPropertyName("account_id")]
			public int Id { get; set; }
		}
	}
}