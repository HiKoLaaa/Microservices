using AccountService.Database.Configurations;
using AccountService.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Database
{
	internal class AccountDbContext : DbContext
	{
		public DbSet<Account> Accounts { get; set; } = null!;

		public AccountDbContext(DbContextOptions<AccountDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.UseSerialColumns();

			modelBuilder.ApplyConfiguration(new AccountConfiguration());
		}
	}
}