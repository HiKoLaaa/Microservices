using System.Threading.Tasks;
using ProfileService.Dtos.Profile;
using ProfileService.Models;

namespace ProfileService.Services.Profiles
{
	public interface IProfileService
	{
		Task<Profile> CreateProfileAsync(ProfileCreateDto createDto);

		Task<Profile> UpdateProfileAsync(ProfileDto profileDto);

		Task DeleteProfileByAccountIdAsync(int accountId);
	}
}