using System;

namespace UserService.Models
{
	public class Profile
	{
		public string FirstName { get; }

		public string LastName { get; }

		public string DepartmentTitle { get; }

		public Profile(string firstName, string lastName, string departmentTitle)
		{
			if (string.IsNullOrWhiteSpace(firstName))
				throw new ArgumentException($"{nameof(firstName)} can not be null or white space.");

			if (string.IsNullOrWhiteSpace(lastName))
				throw new ArgumentException($"{nameof(lastName)} can not be null or white space.");
			
			if (string.IsNullOrWhiteSpace(departmentTitle))
				throw new ArgumentException($"{nameof(departmentTitle)} can not be null or white space.");

			FirstName = firstName;
			LastName = lastName;
			DepartmentTitle = departmentTitle;
		}
	}
}