using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UserService.Dtos;

namespace UserService.Services.Profiles
{
	internal class ProfileService : IProfileService
	{
		private const string ProfilePath = "api/profiles";

		private readonly HttpClient _httpClient;

		public ProfileService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<ProfileResponseDto> AddProfileAsync(ProfileCreateDto createDto)
		{
			var response = await _httpClient.PostAsJsonAsync(ProfilePath, createDto);
			response.EnsureSuccessStatusCode();

			return (await response.Content.ReadFromJsonAsync<ProfileResponseDto>())!;
		}

		public async Task<ProfileResponseDto> UpdateProfileAsync(ProfileDto profileDto)
		{
			var response = await _httpClient.PutAsJsonAsync(ProfilePath, profileDto);
			response.EnsureSuccessStatusCode();
			
			return (await response.Content.ReadFromJsonAsync<ProfileResponseDto>())!;
		}

		public async Task DeleteProfileByAccountIdAsync(int accountId)
		{
			var response = await _httpClient.DeleteAsync($"{ProfilePath}/accounts/{accountId}");
			response.EnsureSuccessStatusCode();
		}

		public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync() =>
			(await _httpClient.GetFromJsonAsync<DepartmentDto[]>("api/departments"))!;
	}
}