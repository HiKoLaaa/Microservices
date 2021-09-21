using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProfileService.Database;
using ProfileService.Models;

namespace AccountService.Services.Accounts
{
	internal class ProfileRepository : IProfileRepository
	{
		private readonly ProfileDbContext _profileDbContext;

		public ProfileRepository(ProfileDbContext profileDbContext)
		{
			_profileDbContext = profileDbContext;
		}

		public async Task<Profile?> GetEntityAsync(int id) => await _profileDbContext.Profiles.FindAsync(id);

		public IEnumerable<Profile> GetEntities() => _profileDbContext.Profiles;

		public void UpdateEntity(Profile updatingEntity) => _profileDbContext.Profiles.Update(updatingEntity);

		public async Task CreateEntityAsync(Profile createdEntity) => await _profileDbContext.Profiles.AddAsync(createdEntity);

		public void DeleteEntity(Profile deletingEntity) => _profileDbContext.Profiles.Remove(deletingEntity);

		public async Task SaveChangesAsync() => await _profileDbContext.SaveChangesAsync();

		public async Task<Profile?> GetProfileByAccountIdAsync(int accountId) =>
			await _profileDbContext.Profiles.SingleOrDefaultAsync(profile => profile.AccountId == accountId);
	}
}