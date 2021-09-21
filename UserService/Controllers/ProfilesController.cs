using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService.Dtos;
using UserService.Services.Profiles;
using UserService.Services.Users;

namespace UserService.Controllers
{
	[Route("api/usr/[controller]")]
	public class ProfilesController : Controller
	{
		private readonly IUserService _userService;
		private readonly IProfileService _profileService;

		public ProfilesController(IUserService userService, IProfileService profileService)
		{
			_userService = userService;
			_profileService = profileService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateProfile([FromBody] ProfileCreateDto profileCreateDto)
		{
			await _userService.AddProfileAsync(profileCreateDto);

			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProfile([FromBody] ProfileDto profileDto)
		{
			await _userService.UpdateProfileAsync(profileDto);

			return Ok();
		}

		[HttpGet("departments")]
		public async Task<IActionResult> GetDepartments()
		{
			var departments =  await _profileService.GetDepartmentsAsync();
			return Ok(
				departments.Select(
					department => new
					{
						id = department.Id,
						title = department.Title
					}));
		}
	}
}