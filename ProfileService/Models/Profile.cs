using System;

namespace ProfileService.Models
{
	public class Profile
	{
		public int Id { get; private set; }

		public int AccountId { get; private set; }

		public string FirstName { get; private set; } = null!;

		public string LastName { get; private set; } = null!;

		public Department Department { get; private set; } = null!;

		public Profile(int accountId, string firstName, string lastName, Department department)
		{
			UpdateAccountId(accountId);
			UpdateFirstName(firstName);
			UpdateLastName(lastName);
			UpdateDepartment(department);
		}

		// For EF Core.
		private Profile()
		{
		}

		public void UpdateAccountId(int newAccountId) => AccountId = newAccountId;

		public void UpdateFirstName(string newFirstName)
		{
			if (string.IsNullOrWhiteSpace(newFirstName))
				throw new ArgumentException($"{nameof(newFirstName)} can not be null or white space.");

			FirstName = newFirstName;
		}

		public void UpdateLastName(string newLastName)
		{
			if (string.IsNullOrWhiteSpace(newLastName))
				throw new ArgumentException($"{nameof(newLastName)} can not be null or white space.");

			LastName = newLastName;
		}

		public void UpdateDepartment(Department department) => Department = department;
	}
}