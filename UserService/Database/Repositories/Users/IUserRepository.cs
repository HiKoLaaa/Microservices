using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Database.Repositories.Users
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User?> GetByAccountIdAsync(int accountId);

		IEnumerable<User> GetUsers();
	}
}