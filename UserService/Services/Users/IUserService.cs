using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Dtos;
using UserService.Models;

namespace UserService.Services.Users
{
	public interface IUserService
	{
		Task<Account> AddAccountAsync(AccountCreateDto createDto);

		Task UpdateAccountAsync(AccountDto accountDto);

		Task AddProfileAsync(ProfileCreateDto createDto);

		Task UpdateProfileAsync(ProfileDto profileDto);

		Task DeleteUserByAccountIdAsync(int accountId);

		Task<User> GetUserByAccountId(int accountId);

		IEnumerable<User> GetUsers();
	}
}