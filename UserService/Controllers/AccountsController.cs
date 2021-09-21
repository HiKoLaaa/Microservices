using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService.Dtos;
using UserService.Services.Users;

namespace UserService.Controllers
{
	[Route("api/usr/[controller]")]
	public class AccountsController : Controller
	{
		private readonly IUserService _userService;

		public AccountsController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAccount([FromBody] AccountCreateDto createDto)
		{
			var newAccount = await _userService.AddAccountAsync(createDto);

			return Ok(new { account_id = newAccount.Id });
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAccount([FromBody] AccountDto accountDto)
		{
			await _userService.UpdateAccountAsync(accountDto);

			return Ok();
		}
	}
}