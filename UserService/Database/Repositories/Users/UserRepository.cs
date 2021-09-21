using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Database.Repositories.Users
{
	internal class UserRepository : IUserRepository
	{
		private readonly UserDbContext _userDbContext;

		public UserRepository(UserDbContext userDbContext)
		{
			_userDbContext = userDbContext;
		}

		public async Task<User?> GetEntityAsync(int id) => await _userDbContext.Users.FindAsync(id);

		public void UpdateEntity(User updatingEntity) => _userDbContext.Users.Update(updatingEntity);

		public async Task CreateEntityAsync(User createdEntity) => await _userDbContext.Users.AddAsync(createdEntity);

		public void DeleteEntity(User deletingEntity) => _userDbContext.Users.Remove(deletingEntity);

		public async Task<User?> GetByAccountIdAsync(int accountId) =>
			await _userDbContext.Users.SingleOrDefaultAsync(user => user.Account.Id == accountId);

		public IEnumerable<User> GetUsers() => _userDbContext.Users;

		public async Task SaveChangesAsync() => await _userDbContext.SaveChangesAsync();
	}
}