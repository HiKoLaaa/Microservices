using System;
using System.Threading.Tasks;
using AccountService.Database.Repositories;
using AccountService.Dtos.Accounts;
using AccountService.Models;

namespace AccountService.Services
{
	internal class AccountService : IAccountService
	{
		private readonly IRepository<Account> _accountRepository;

		public AccountService(IRepository<Account> accountRepository)
		{
			_accountRepository = accountRepository;
		}

		public async Task<Account> CreateAccountAsync(AccountCreateDto createDto)
		{
			if (string.IsNullOrWhiteSpace(createDto.Name))
				throw new InvalidOperationException($"{nameof(createDto.Name)} can not be null or white space.");
			
			if (string.IsNullOrWhiteSpace(createDto.Email))
				throw new InvalidOperationException($"{nameof(createDto.Email)} can not be null or white space.");

			var newAccount = new Account(createDto.Name, createDto.Email);

			await _accountRepository.CreateEntityAsync(newAccount);
			await _accountRepository.SaveChangesAsync();

			return newAccount;
		}

		public async Task UpdateAccountAsync(AccountDto accountDto)
		{
			if (string.IsNullOrWhiteSpace(accountDto.Name))
				throw new InvalidOperationException($"{nameof(accountDto.Name)} can not be null or white space.");

			if (string.IsNullOrWhiteSpace(accountDto.Email))
				throw new InvalidOperationException($"{nameof(accountDto.Email)} can not be null or white space.");

			var existingAccount = await _accountRepository.GetEntityAsync(accountDto.Id);
			if (existingAccount is null)
				throw new InvalidOperationException($"Account with id = {accountDto.Id} does not exists.");

			_accountRepository.UpdateEntity(existingAccount);

			existingAccount.UpdateEmail(accountDto.Email);
			existingAccount.UpdateName(accountDto.Name);

			await _accountRepository.SaveChangesAsync();
		}

		public async Task DeleteAccountAsync(int id)
		{
			var existingAccount = await _accountRepository.GetEntityAsync(id);
			if (existingAccount is null)
				throw new InvalidOperationException($"Account with id = {id} not exists.");

			_accountRepository.DeleteEntity(existingAccount);
			await _accountRepository.SaveChangesAsync();
		}

		public async Task<Account> GetAccountAsync(int id)
		{
			var account = await _accountRepository.GetEntityAsync(id);
			if (account is null)
				throw new InvalidOperationException($"Account with id = {id} not exists.");

			return account;
		}
	}
}