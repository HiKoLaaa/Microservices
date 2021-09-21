using System.Threading.Tasks;
using AccountService.Dtos.Accounts;
using AccountService.Models;

namespace AccountService.Services
{
	public interface IAccountService
	{
		Task<Account> CreateAccountAsync(AccountCreateDto createDto);

		Task UpdateAccountAsync(AccountDto accountDto);

		Task DeleteAccountAsync(int id);

		Task<Account> GetAccountAsync(int id);
	}
}