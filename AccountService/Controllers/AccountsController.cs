using System.Threading.Tasks;
using AccountService.Dtos.Accounts;
using AccountService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers
{
	[Route("api/[controller]")]
	public class AccountsController : Controller
	{
		private readonly IAccountService _accountService;

		public AccountsController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAccount([FromBody] AccountCreateDto accountCreateDto)
		{
			var newAccount = await _accountService.CreateAccountAsync(accountCreateDto);

			return Ok(new { account_id = newAccount.Id });
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAccount([FromBody] AccountDto accountDto)
		{
			await _accountService.UpdateAccountAsync(accountDto);

			return Ok();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteAccount(int id)
		{
			await _accountService.DeleteAccountAsync(id);

			return Ok();
		}
	}
}