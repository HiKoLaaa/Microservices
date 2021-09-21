using Microsoft.EntityFrameworkCore;
using ProfileService.Database.Configurations;
using ProfileService.Models;

namespace ProfileService.Database
{
	internal class ProfileDbContext : DbContext
	{
		public DbSet<Profile> Profiles { get; set; } = null!;

		public DbSet<Department> Departments { get; set; } = null!;

		public ProfileDbContext(DbContextOptions<ProfileDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.UseSerialColumns();

			modelBuilder.ApplyConfiguration(new ProfileConfiguration());
			modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
		}
	}
}