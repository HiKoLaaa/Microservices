using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Database.Repositories.Users;
using UserService.Dtos;
using UserService.Models;
using UserService.Services.Accounts;
using UserService.Services.Profiles;

namespace UserService.Services.Users
{
	internal class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		private readonly IAccountService _accountService;

		private readonly IProfileService _profileService;

		public UserService(IUserRepository userRepository, IAccountService accountService, IProfileService profileService)
		{
			_userRepository = userRepository;
			_accountService = accountService;
			_profileService = profileService;
		}

		public async Task<Account> AddAccountAsync(AccountCreateDto createDto)
		{
			if (string.IsNullOrWhiteSpace(createDto.Name))
				throw new InvalidOperationException($"{nameof(createDto.Name)} can not be null or white space.");

			if (string.IsNullOrWhiteSpace(createDto.Email))
				throw new InvalidOperationException($"{nameof(createDto.Email)} can not be null or white space.");

			var newAccountId = await _accountService.AddAccountAsync(createDto);
			var newAccount = new Account(newAccountId, createDto.Name, createDto.Email);

			var newUser = new User(newAccount, profile: null);
			await _userRepository.CreateEntityAsync(newUser);
			await _userRepository.SaveChangesAsync();

			return newAccount;
		}

		public async Task UpdateAccountAsync(AccountDto accountDto)
		{
			if (string.IsNullOrWhiteSpace(accountDto.Name))
				throw new InvalidOperationException($"{nameof(accountDto.Name)} can not be null or white space.");

			if (string.IsNullOrWhiteSpace(accountDto.Email))
				throw new InvalidOperationException($"{nameof(accountDto.Email)} can not be null or white space.");

			var user = await GetUserByAccountId(accountDto.Id);

			await _accountService.UpdateAccountAsync(accountDto);

			_userRepository.UpdateEntity(user);
			var updatedAccount = new Account(accountDto.Id, accountDto.Name, accountDto.Email);

			user.UpdateAccount(updatedAccount);
			await _userRepository.SaveChangesAsync();
		}

		public async Task AddProfileAsync(ProfileCreateDto createDto)
		{
			if (string.IsNullOrWhiteSpace(createDto.FirstName))
				throw new InvalidOperationException($"{nameof(createDto.FirstName)} can not be null or white space.");

			if (string.IsNullOrWhiteSpace(createDto.LastName))
				throw new InvalidOperationException($"{nameof(createDto.LastName)} can not be null or white space.");

			var user = await GetUserByAccountId(createDto.AccountId);

			var addedProfileDto = await _profileService.AddProfileAsync(createDto);
			var newProfile = new Profile(createDto.FirstName, createDto.LastName, addedProfileDto.DepartmentTitle);

			await UpdateProfile(user, newProfile);
		}

		public async Task UpdateProfileAsync(ProfileDto profileDto)
		{
			if (string.IsNullOrWhiteSpace(profileDto.FirstName))
				throw new InvalidOperationException($"{nameof(profileDto.FirstName)} can not be null or white space.");

			if (string.IsNullOrWhiteSpace(profileDto.LastName))
				throw new InvalidOperationException($"{nameof(profileDto.LastName)} can not be null or white space.");

			var user = await GetUserByAccountId(profileDto.AccountId);

			var updatedProfileDto = await _profileService.UpdateProfileAsync(profileDto);
			var updatedProfile = new Profile(profileDto.FirstName, profileDto.LastName, updatedProfileDto.DepartmentTitle);

			await UpdateProfile(user, updatedProfile);
		}

		public async Task DeleteUserByAccountIdAsync(int accountId)
		{
			var user = await _userRepository.GetByAccountIdAsync(accountId);
			if (user is null)
				throw new InvalidOperationException($"Account with id = {accountId} does not exists.");

			await Task.WhenAll(
				_accountService.DeleteAccountAsync(accountId),
				user.Profile is null ? Task.CompletedTask : _profileService.DeleteProfileByAccountIdAsync(accountId));

			_userRepository.DeleteEntity(user);
			await _userRepository.SaveChangesAsync();
		}

		public async Task<User> GetUserByAccountId(int accountId)
		{
			var user = await _userRepository.GetByAccountIdAsync(accountId);
			if (user is null)
				throw new InvalidOperationException($"Account with id = {accountId} does not exists.");

			return user;
		}

		public IEnumerable<User> GetUsers() => _userRepository.GetUsers();

		private async Task UpdateProfile(User user, Profile profile)
		{
			_userRepository.UpdateEntity(user);
			user.UpdateProfile(profile);

			await _userRepository.SaveChangesAsync();
		}
	}
}