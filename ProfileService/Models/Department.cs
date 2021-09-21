using System;
using System.Collections.Generic;

namespace ProfileService.Models
{
	public class Department
	{
		public int Id { get; private set; }

		public string Title { get; private set; } = null!;

		public ICollection<Profile> Profiles { get; set; } = new List<Profile>();

		public Department(string title)
		{
			UpdateTitle(title);
		}

		// For EF Core only.
		private Department()
		{
		}

		public void UpdateTitle(string newTitle)
		{
			if (string.IsNullOrWhiteSpace(newTitle))
				throw new ArgumentException($"{nameof(newTitle)} can not be null or white space.");

			Title = newTitle;
		}
	}
}