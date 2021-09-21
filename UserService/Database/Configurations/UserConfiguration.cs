using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.NameTranslation;
using UserService.Models;

namespace UserService.Database.Configurations
{
	internal class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(user => user.Id);

			builder
				.OwnsOne(
					user => user.Account,
					account =>
					{
						account
							.Property(acc => acc.Id)
							.IsRequired()
							.HasColumnType("integer")
							.HasColumnName(
								NpgsqlSnakeCaseNameTranslator.ConvertToSnakeCase($"{nameof(Account)}{nameof(Account.Id)}"));

						account
							.Property(acc => acc.Name)
							.IsRequired()
							.HasColumnType("varchar(100)")
							.HasColumnName(NpgsqlSnakeCaseNameTranslator.ConvertToSnakeCase(nameof(Account.Name)));

						account
							.Property(acc => acc.Email)
							.IsRequired()
							.HasColumnType("varchar(100)")
							.HasColumnName(NpgsqlSnakeCaseNameTranslator.ConvertToSnakeCase(nameof(Account.Email)));
					})
				.Navigation(user => user.Account)
				.IsRequired();

			builder
				.OwnsOne(
					user => user.Profile,
					profile =>
					{
						profile
							.Property(prf => prf!.FirstName)
							.HasColumnType("varchar(100)")
							.HasColumnName(NpgsqlSnakeCaseNameTranslator.ConvertToSnakeCase(nameof(Profile.FirstName)));

						profile
							.Property(prf => prf!.LastName)
							.HasColumnType("varchar(100)")
							.HasColumnName(NpgsqlSnakeCaseNameTranslator.ConvertToSnakeCase(nameof(Profile.LastName)));

						profile
							.Property(prf => prf!.DepartmentTitle)
							.HasColumnType("varchar(100)")
							.HasColumnName(NpgsqlSnakeCaseNameTranslator.ConvertToSnakeCase(nameof(Profile.DepartmentTitle)));
					});
		}
	}
}