using AccountService.Services.Accounts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProfileService.Database;
using ProfileService.Database.Repositories;
using ProfileService.Database.Repositories.Departments;
using ProfileService.Models;
using ProfileService.Services.Departments;
using ProfileService.Services.Profiles;

namespace ProfileService
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ProfileDbContext>(options =>
				options.UseNpgsql(_configuration["ConnectionString"]).UseSnakeCaseNamingConvention());

			services.AddScoped<IProfileRepository, ProfileRepository>();
			services.AddScoped<IRepository<Department>, DepartmentRepository>();
			services.AddScoped<IProfileService, Services.Profiles.ProfileService>();
			services.AddScoped<IDepartmentService, DepartmentService>();

			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(routeBuilder => routeBuilder.MapControllers());
		}
	}
}