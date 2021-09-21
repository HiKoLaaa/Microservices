using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfileService.Models;

namespace ProfileService.Database.Configurations
{
	internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.HasKey(department => department.Id);

			builder.Property(department => department.Title).IsRequired().HasColumnType("varchar(100)");
		}
	}
}