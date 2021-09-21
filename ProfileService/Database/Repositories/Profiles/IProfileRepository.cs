using System.Threading.Tasks;
using ProfileService.Database.Repositories;
using ProfileService.Models;

namespace AccountService.Services.Accounts
{
	public interface IProfileRepository : IRepository<Profile>
	{
		Task<Profile?> GetProfileByAccountIdAsync(int accountId);
	}
}