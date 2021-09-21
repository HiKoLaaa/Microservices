using System;

namespace UserService.Models
{
	public class Account
	{
		public int Id { get; }

		public string Name { get; }

		public string Email { get; }

		public Account(int id, string name, string email)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException($"{nameof(name)} can not be null or white space.");

			if (string.IsNullOrWhiteSpace(email))
				throw new ArgumentException($"{nameof(email)} can not be null or white space.");

			Id = id;
			Name = name;
			Email = email;
		}
	}
}