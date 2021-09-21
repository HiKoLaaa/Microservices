using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Dtos;

namespace UserService.Services.Profiles
{
	public interface IProfileService
	{
		Task<ProfileResponseDto> AddProfileAsync(ProfileCreateDto createDto);

		Task<ProfileResponseDto> UpdateProfileAsync(ProfileDto profileDto);

		Task DeleteProfileByAccountIdAsync(int accountId);

		Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync();
	}
}