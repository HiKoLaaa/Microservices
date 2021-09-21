using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Dtos.Profile;
using ProfileService.Services.Profiles;

namespace ProfileService.Controllers
{
	[Route("api/[controller]")]
	public class ProfilesController : Controller
	{
		private readonly IProfileService _profileService;

		public ProfilesController(IProfileService profileService)
		{
			_profileService = profileService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateProfile([FromBody] ProfileCreateDto profileCreateDto)
		{
			var newProfile = await _profileService.CreateProfileAsync(profileCreateDto);

			return Ok(new { department_title = newProfile.Department.Title });
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProfile([FromBody] ProfileDto profileDto)
		{
			var updatedProfile = await _profileService.UpdateProfileAsync(profileDto);

			return Ok(new { department_title = updatedProfile.Department.Title });
		}

		[HttpDelete("accounts/{accountId:int}")]
		public async Task<IActionResult> DeleteProfileByAccountId(int accountId)
		{
			await _profileService.DeleteProfileByAccountIdAsync(accountId);

			return Ok();
		}
	}
}