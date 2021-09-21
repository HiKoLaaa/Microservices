using System;
using System.Threading.Tasks;
using AccountService.Services.Accounts;
using ProfileService.Database.Repositories;
using ProfileService.Dtos.Profile;
using ProfileService.Models;

namespace ProfileService.Services.Profiles
{
	internal class ProfileService : IProfileService
	{
		private readonly IProfileRepository _profileRepository;

		private readonly IRepository<Department> _departmentRepository;

		public ProfileService(IProfileRepository profileRepository, IRepository<Department> departmentRepository)
		{
			_profileRepository = profileRepository;
			_departmentRepository = departmentRepository;
		}

		public async Task<Profile> CreateProfileAsync(ProfileCreateDto createDto)
		{
			if (string.IsNullOrWhiteSpace(createDto.FirstName))
				throw new InvalidOperationException($"{nameof(createDto.FirstName)} can not be null or white space.");

			if (string.IsNullOrWhiteSpace(createDto.LastName))
				throw new InvalidOperationException($"{nameof(createDto.LastName)} can not be null or white space.");

			var department = await _departmentRepository.GetEntityAsync(createDto.DepartmentId);
			if (department is null)
				throw new InvalidOperationException($"Department with id = {createDto.DepartmentId} does not exists.");

			var newProfile = new Profile(createDto.AccountId, createDto.FirstName, createDto.LastName, department);
			await _profileRepository.CreateEntityAsync(newProfile);

			await _profileRepository.SaveChangesAsync();

			return newProfile;
		}

		public async Task<Profile> UpdateProfileAsync(ProfileDto profileDto)
		{
			if (string.IsNullOrWhiteSpace(profileDto.FirstName))
				throw new InvalidOperationException($"{nameof(profileDto.FirstName)} can not be null or white space.");

			if (string.IsNullOrWhiteSpace(profileDto.LastName))
				throw new InvalidOperationException($"{nameof(profileDto.LastName)} can not be null or white space.");

			var existingProfile = await _profileRepository.GetProfileByAccountIdAsync(profileDto.AccountId);
			if (existingProfile is null)
				throw new InvalidOperationException($"Linked account with id = {profileDto.AccountId} does not exists.");

			var department = await _departmentRepository.GetEntityAsync(profileDto.DepartmentId);
			if (department is null)
				throw new InvalidOperationException($"Department with id = {profileDto.DepartmentId} does not exists.");

			_profileRepository.UpdateEntity(existingProfile);

			existingProfile.UpdateAccountId(profileDto.AccountId);
			existingProfile.UpdateDepartment(department);
			existingProfile.UpdateFirstName(profileDto.FirstName);
			existingProfile.UpdateLastName(profileDto.LastName);

			await _profileRepository.SaveChangesAsync();

			return existingProfile;
		}

		public async Task DeleteProfileByAccountIdAsync(int id)
		{
			var deletingProfile = await _profileRepository.GetProfileByAccountIdAsync(id);
			if (deletingProfile is null)
				throw new InvalidOperationException($"Profile with account id = {id} does not exists.");

			_profileRepository.DeleteEntity(deletingProfile);

			await _profileRepository.SaveChangesAsync();
		}
	}
}