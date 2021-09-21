using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserService.Database;
using UserService.Database.Repositories.Users;
using UserService.Services.Accounts;
using UserService.Services.Profiles;
using UserService.Services.Users;

namespace UserService
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
			services.AddDbContext<UserDbContext>(options =>
				options.UseNpgsql(_configuration["ConnectionString"]).UseSnakeCaseNamingConvention());

			services.AddScoped<IUserRepository, UserRepository>();
			services.AddHttpClient<IAccountService, AccountService>(
				httpClient => httpClient.BaseAddress = new Uri(_configuration["Url:AccountService"]));
			
			services.AddHttpClient<IProfileService, ProfileService>(
				httpClient => httpClient.BaseAddress = new Uri(_configuration["Url:ProfileService"]));

			services.AddScoped<IUserService, Services.Users.UserService>();

			services.AddControllers();
			services.AddCors();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
			app.UseRouting();

			app.UseEndpoints(routeBuilder => routeBuilder.MapControllers());
		}
	}
}