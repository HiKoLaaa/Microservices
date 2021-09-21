using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService.Dtos;
using UserService.Services.Users;

namespace UserService.Controllers
{
	[Route("api/usr/[controller]")]
	public class UsersController : Controller
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public IActionResult GetUsers()
		{
			var allUsers = _userService.GetUsers();

			return Ok(
				allUsers.Select(
					user => new UserDto
					{
						AccountEmail = user.Account.Email,
						AccountId = user.Account.Id,
						AccountName = user.Account.Name,
						ProfileFirstName = user.Profile?.FirstName,
						ProfileLastName = user.Profile?.LastName,
						ProfileDepartmentTitle = user.Profile?.DepartmentTitle
					}));
		}

		[HttpDelete("accounts/{accountId:int}")]
		public async Task<IActionResult> DeleteUser(int accountId)
		{
			await _userService.DeleteUserByAccountIdAsync(accountId);

			return Ok();
		}

		[HttpGet("accounts/{accountId:int}")]
		public async Task<IActionResult> GetUserByAccountId(int accountId)
		{
			var user = await _userService.GetUserByAccountId(accountId);

			return Ok(
				new UserDto
				{
					AccountEmail = user.Account.Email,
					AccountId = user.Account.Id,
					AccountName = user.Account.Name,
					ProfileFirstName = user.Profile?.FirstName,
					ProfileLastName = user.Profile?.LastName,
					ProfileDepartmentTitle = user.Profile?.DepartmentTitle
				});
		}
	}
}