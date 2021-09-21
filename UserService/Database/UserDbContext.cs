using Microsoft.EntityFrameworkCore;
using UserService.Database.Configurations;
using UserService.Models;

namespace UserService.Database
{
	internal class UserDbContext : DbContext
	{
		public DbSet<User> Users { get; set; } = null!;

		public UserDbContext(DbContextOptions<UserDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.UseSerialColumns();

			modelBuilder.ApplyConfiguration(new UserConfiguration());
		}
	}
}