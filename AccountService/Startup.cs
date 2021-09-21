using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Database;
using AccountService.Database.Repositories;
using AccountService.Models;
using AccountService.Services;
using AccountService.Services.Accounts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AccountService
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
			services.AddDbContext<AccountDbContext>(options =>
				options.UseNpgsql(_configuration["ConnectionString"]).UseSnakeCaseNamingConvention());

			services.AddScoped<IRepository<Account>, AccountRepository>();
			services.AddScoped<IAccountService, Services.AccountService>();

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