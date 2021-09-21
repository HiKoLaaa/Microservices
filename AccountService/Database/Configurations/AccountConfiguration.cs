using AccountService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountService.Database.Configurations
{
	internal class AccountConfiguration : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> builder)
		{
			builder.HasKey(account => account.Id);

			builder.Property(account => account.Name).IsRequired().HasColumnType("varchar(100)");
			builder.Property(account => account.Email).IsRequired().HasColumnType("varchar(100)");
		}
	}
}