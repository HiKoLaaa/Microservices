namespace UserService.Models
{
	public class User
	{
		public int Id { get; private set; }

		public Account Account { get; private set; } = null!;

		public Profile? Profile { get; private set; }

		public User(Account account, Profile? profile)
		{
			UpdateAccount(account);
			UpdateProfile(profile);
		}

		// For EF Core only.
		private User()
		{
		}

		public void UpdateAccount(Account account) => Account = account;

		public void UpdateProfile(Profile? profile) => Profile = profile;
	}
}