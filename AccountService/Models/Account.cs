using System;

namespace AccountService.Models
{
	public class Account
	{
		public int Id { get; private set; }

		public string Name { get; private set; } = null!;

		public string Email { get; private set; } = null!;

		public Account(string name, string email)
		{
			UpdateName(name);
			UpdateEmail(email);
		}

		// For EF Core only.
		private Account()
		{
		}

		public void UpdateName(string newName)
		{
			if (string.IsNullOrWhiteSpace(newName))
				throw new ArgumentException($"{nameof(newName)} can not be null or white space.");

			Name = newName;
		}

		public void UpdateEmail(string newEmail)
		{
			if (string.IsNullOrWhiteSpace(newEmail))
				throw new ArgumentException($"{nameof(newEmail)} can not be null or white space.");

			Email = newEmail;
		}
	}
}