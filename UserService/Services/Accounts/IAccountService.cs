using System.Threading.Tasks;
using UserService.Dtos;

namespace UserService.Services.Accounts
{
	public interface IAccountService
	{
		Task<int> AddAccountAsync(AccountCreateDto createDto);

		Task UpdateAccountAsync(AccountDto accountDto);

		Task DeleteAccountAsync(int accountId);
	}
}