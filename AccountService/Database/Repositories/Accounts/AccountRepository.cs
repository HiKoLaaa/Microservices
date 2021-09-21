using System.Threading.Tasks;
using AccountService.Database;
using AccountService.Database.Repositories;
using AccountService.Models;

namespace AccountService.Services.Accounts
{
	internal class AccountRepository : IRepository<Account>
	{
		private readonly AccountDbContext _accountDbContext;

		public AccountRepository(AccountDbContext accountDbContext)
		{
			_accountDbContext = accountDbContext;
		}

		public async Task<Account?> GetEntityAsync(int id) => await _accountDbContext.Accounts.FindAsync(id);

		public void UpdateEntity(Account updatingAccount) => _accountDbContext.Accounts.Update(updatingAccount);

		public async Task CreateEntityAsync(Account createdAccount) => await _accountDbContext.Accounts.AddAsync(createdAccount);

		public void DeleteEntity(Account deletingAccount) => _accountDbContext.Accounts.Remove(deletingAccount);

		public async Task SaveChangesAsync() => await _accountDbContext.SaveChangesAsync();
	}
}