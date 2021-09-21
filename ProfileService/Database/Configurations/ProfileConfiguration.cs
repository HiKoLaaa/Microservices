using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfileService.Models;

namespace ProfileService.Database.Configurations
{
	internal class ProfileConfiguration : IEntityTypeConfiguration<Profile>
	{
		public void Configure(EntityTypeBuilder<Profile> builder)
		{
			builder.HasKey(profile => profile.Id);

			builder.Property(profile => profile.FirstName).IsRequired().HasColumnType("varchar(100)");
			builder.Property(profile => profile.LastName).IsRequired().HasColumnType("varchar(100)");
			builder
				.HasOne(profile => profile.Department)
				.WithMany(department => department.Profiles)
				.IsRequired()
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}